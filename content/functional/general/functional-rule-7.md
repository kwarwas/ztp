## Immutability

    class Person {
        public string Name { get; }
        public int Age { get; }

        public Person(string name, int age) {
            Name = name;
            Age = age;
        }
    }

    public bool IsFemale(Person person) {
        // person.Age += 10; compilation error
        return person.Name.EndsWith("a");
    }
