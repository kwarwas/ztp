## Side-effect

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        
        public bool IsFemale()
        {
            person.Age += 10;
            return Name.EndsWith("a");
        }
    }