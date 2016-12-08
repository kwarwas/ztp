## Fluent interface - example

    private ISessionFactory CreateSessionFactory()
    {
        return Fluently
            .Configure()
            .Database
            (
                SQLiteConfiguration.Standard.UsingFile("firstProject.db")
            )
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Program>())
            .ExposeConfiguration(BuildSchema)
            .BuildSessionFactory();
    }

> Fluent NHibernate, http://www.fluentnhibernate.org/
