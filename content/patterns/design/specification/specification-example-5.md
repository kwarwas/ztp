## Specification design pattern

Przykładowa implementacja z [LinqKit](https://github.com/scottksmith95/LINQKit):

    static async Task<Person[]> GetPeople(
        string filter, ushort age) 
    {
        using (var context = new PeopleContext())
        {
            var specification = new FilterSpecification(filter)
                .And(new OlderThanSpecification(age));

            return await context.People
                .Where(specification.ToExpression())
                .ToArrayAsync();
        }
    }
