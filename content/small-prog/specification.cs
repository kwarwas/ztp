using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SpecificationApp
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public bool IsDeleted { get; set; }
        public bool FromOldDb { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName} | Id: {Id} | Age: {Age})";
        }
    }

    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("People");
        }
    }

    public class PeopleContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseMySql("Server=localhost;database=Test;uid=root;pwd=password;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PersonConfiguration());
        }
    }

    public abstract class Specification<T>
    {
        public abstract Expression<Func<T, bool>> ToExpression();

        public Specification<T> And(Specification<T> specification)
        {
            return new AndSpecification<T>(this, specification);
        }

        public Specification<T> Or(Specification<T> specification)
        {
            return new OrSpecification<T>(this, specification);
        }
    }

    public class AndSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _left;
        private readonly Specification<T> _right;

        public AndSpecification(Specification<T> left, Specification<T> right)
        {
            _right = right;
            _left = left;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            return _right.ToExpression().And(_left.ToExpression());
        }
    }

    public class OrSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _left;
        private readonly Specification<T> _right;

        public OrSpecification(Specification<T> left, Specification<T> right)
        {
            _right = right;
            _left = left;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            return _right.ToExpression().Or(_left.ToExpression());
        }
    }

    public class PersonNotDeletedSpecification : Specification<Person>
    {
        public override Expression<Func<Person, bool>> ToExpression()
        {
            return x => !x.IsDeleted && !x.FromOldDb;
        }
    }

    public class PersonOlderThanSpecification : Specification<Person>
    {
        private readonly ushort _age;

        public PersonOlderThanSpecification(ushort age)
        {
            _age = age;
        }

        public override Expression<Func<Person, bool>> ToExpression()
        {
            return x => x.Age > _age;
        }
    }

    public class PersonFilterSpecification : Specification<Person>
    {
        private readonly string _filter;

        public PersonFilterSpecification(string filter)
        {
            _filter = filter;
        }

        public override Expression<Func<Person, bool>> ToExpression()
        {
            if (!string.IsNullOrWhiteSpace(_filter))
            {
                return x => x.FirstName.Contains(_filter) || x.LastName.Contains(_filter);
            }

            return x => true;
        }
    }

    public class Program
    {
        static async Task InsertData()
        {
            using (var context = new PeopleContext())
            {
                if (!context.People.Any())
                {
                    var people = new[]
                    {
                        new Person
                        {
                            FirstName = "Jan",
                            LastName = "Kowalski",
                            Age = 15,
                            IsDeleted = false,
                            FromOldDb = false
                        },
                        new Person
                        {
                            FirstName = "Adam",
                            LastName = "Nowak",
                            Age = 23,
                            IsDeleted = false,
                            FromOldDb = false
                        },
                        new Person
                        {
                            FirstName = "Katarzyna",
                            LastName = "Malinowska",
                            Age = 34,
                            IsDeleted = true,
                            FromOldDb = false
                        },
                        new Person
                        {
                            FirstName = "Aleksandra",
                            LastName = "Musiał",
                            Age = 25,
                            IsDeleted = false,
                            FromOldDb = true
                        },
                        new Person
                        {
                            FirstName = "Marzena",
                            LastName = "Wieczorek",
                            Age = 88,
                            IsDeleted = true,
                            FromOldDb = false
                        },
                        new Person
                        {
                            FirstName = "Ela",
                            LastName = "Ostrowska",
                            Age = 19,
                            IsDeleted = false,
                            FromOldDb = true
                        },
                        new Person
                        {
                            FirstName = "Jarek",
                            LastName = "Michalski",
                            Age = 61,
                            IsDeleted = false,
                            FromOldDb = false
                        }
                    };

                    await context.People.AddRangeAsync(people);

                    context.SaveChanges();
                }
            }
        }

        static void Main(string[] args)
        {
            //docker run -e MYSQL_ROOT_PASSWORD=password -p 3306:3306 -d dnhsoft/mysql-utf8

            InsertData().Wait();

            foreach (var person in GetPeople("", 20).Result)
            {
                Console.WriteLine(person);
            }

            Console.WriteLine();

            Console.WriteLine(GetPerson(19).Result);
        }

        static async Task<Person[]> GetPeople(string filter, ushort age)
        {
            using (var context = new PeopleContext())
            {
                var personNotDeletedSpecification = new PersonNotDeletedSpecification();
                var personOlderThanSpecification = new PersonOlderThanSpecification(age);
                var personFilterSpecification = new PersonFilterSpecification(filter);

                var peopleSpecification = personNotDeletedSpecification
                    .And(personOlderThanSpecification.Or(personFilterSpecification));

                return await context.People
                    .Where(peopleSpecification.ToExpression())
                    .ToArrayAsync();
            }
        }
        
        static async Task<Person> GetPerson(int id)
        {
            using (var context = new PeopleContext())
            {
                var personNotDeletedSpecification = new PersonNotDeletedSpecification();

                return await context.People
                    .Where(personNotDeletedSpecification.ToExpression())
                    .FirstOrDefaultAsync(x => x.Id == id);
            }
        }
    }
}