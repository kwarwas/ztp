## StringBuilder - traditional

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {Name}");
            sb.AppendLine($"Age: {Age}");
            sb.Replace("ł", "l");
            var result = sb.ToString();
            return result;
        }
    }