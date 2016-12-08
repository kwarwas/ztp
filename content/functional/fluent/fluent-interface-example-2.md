## Fluent interface - example

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    var person = FluentBuilder<Person>
        .New()
        .With(x => x.Name, "Jan Kowalski")
        .With(x => x.Age, 22)
        .Build();

> Fluent Builder, https://github.com/robsoncastilho/FluentBuilder
