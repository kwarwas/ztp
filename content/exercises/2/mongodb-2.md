## mongoDB w .NET

- Zainstalować paczkę: `Install-Package MongoDB.Driver`
- Dodać fragment kodu:


    var client = new MongoClient("mongodb://localhost:27017");
    var database = client.GetDatabase("pizzaStore");
    var collection = database.GetCollection<Pizza>("pizza");