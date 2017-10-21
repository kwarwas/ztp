## Specification design pattern

Przykładowa implementacja z [LinqKit](https://github.com/scottksmith95/LINQKit):

    static async Task<Person[]> GetPeople(string filter)
    {
        using (var context = new PeopleContext())
        {
            var filter = new FilterSpecification(filter);

            return await context.People
                .Where(filter.ToExpression())
                .ToArrayAsync();
        }
    }
