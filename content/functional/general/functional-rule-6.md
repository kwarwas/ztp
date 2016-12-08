## Immutability

Good? - No

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public bool IsFemale(Person person)
    {
        person.Age += 10;
        return person.Name.EndsWith("a");
    }
