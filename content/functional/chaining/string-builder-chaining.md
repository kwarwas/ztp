## StringBuilder - method chaining

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return new StringBuilder()
                .AppendLine($"Name: {Name}")
                .AppendLine($"Age: {Age}")
                .Replace("ł", "l")
                .ToString();
        }
    }