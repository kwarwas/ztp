## mongoDB w .NET

    public class Pizza
    {
        [BsonId]
        [BsonElement("_id")]
        public ObjectId Id { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<PizzaContent> Contents { get; set; }
    }
    public class PizzaContent
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string LanguageCode { get; set; }
    }