using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ConsoleApplication
{
    public class Pizza
    {
        [BsonId]
        [BsonElement("_id")]
        public ObjectId Id { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<PizzaContent> Contents { get; set; }
    }

    public class PizzaContent
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string LanguageCode { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("pizzaStore");
            var collection = database.GetCollection<Pizza>("pizza");

            SaveItems(collection);

            var items = collection.AsQueryable()
                .Where(x => x.Price == 27.00)
                .ToArray();

            foreach (var item in items)
            {
                Console.WriteLine(item.Id);
            }
        }

        private static void SaveItems(IMongoCollection<Pizza> collection)
        {
            var pizzaList = new[]
            {
                new Pizza
                {
                    Price = 24.50,
                    ImageUrl = "http://www.kuchnia-domowa.pl/images/content/232/2.jpg",
                    Contents = new[]
                    {
                        new PizzaContent
                        {
                            Name = "Pizza Margherita",
                            Description = "Mąkę, olej, sól, drożdże i 150ml ciepłej wody zagnieść na jednolite ciasto. Odstawić w ciepłe miejsce do wyrośnięcia na 45 minut. Wyrośnięte ciasto podzielić na pół. Na dwóch blachach wyłożonych papierem do pieczenia uformować z ciasta placek w kształcie koła. Pizze posmarować sosem pomidorowym. Przyprawić solą. Mozzarellę osuszyć i pokroić w plasterki. Razem z listkami bazylii ułożyć na pizzy. Skropić oliwą. Każdą blachę piec w nagrzanym piekarniku ok. 20 minut w temperaturze 220°C",
                            LanguageCode = "pl-PL"
                        },
                        new PizzaContent
                        {
                            Name = "Pizza Margherita",
                            Description = "Flour, oil, salt, yeast and 150ml of warm water to knead the dough uniform. Set aside in a warm place to rise for 45 minutes. When dough divide in half. Two pans lined with parchment paper formed into a cake dough in the shape of a circle. Pizzas spread with tomato sauce. Season with salt. Mozzarella dry and cut into slices. Together with basil leaves lay on the pizza. Drizzle with olive oil. Each sheet bake in preheated oven for approx. 20 minutes at 220°C",
                            LanguageCode = "en-GB"
                        },
                    }
                },
                new Pizza
                {
                    Price = 27.00,
                    ImageUrl = "http://www.kuchnia-domowa.pl/images/content/96/pizza_hawajska_2.jpg",
                    Contents = new[]
                    {
                        new PizzaContent
                        {
                            Name = "Pizza Hawajska",
                            Description = "Drożdże pokruszyć i wymieszać z wodą. Dodać cukier, 2-3 łyżki mąki i odstawić na 10 minut. W dużej misce wymieszać resztę mąki z solą. Zaczyn dodać do mąki razem z olejem. Wyrobić na gładką masę. Ciasto przykryć ściereczką i odstawić na 40 minut w ciepłe miejsce. Ciasto wyłożyć na największą blachę posmarowaną tłuszczem. Posmarować sosem pomidorowym. Posypać oregano i bazylią. Nałożyć plastry szynki, plastry lub pokrojonego w kostkę ananasa i posypać startym serem. Piec w nagrzanym piekarniku ok. 30minut w temperaturze 180°C.",
                            LanguageCode = "pl-PL"
                        },
                        new PizzaContent
                        {
                            Name = "Гавайский Pizza",
                            Description = "Раскрошить дрожжи и смешать с водой. Добавьте сахар, 2-3 столовые ложки муки и дать постоять 10 минут. В большой миске смешайте оставшуюся часть муки с солью. Закваске добавить в муку вместе с маслом. Месить до получения однородной массы. Накройте тесто салфеткой и дать постоять 40 минут в теплом месте. Торт поставить на самый большой лист смазывают смазкой. Спред с томатным соусом. Посыпать орегано и базилик. Поместите ломтики ветчины, нарезанный или нарезанный кубиками ананас и посыпать тертым сыром. Выпекать в предварительно разогретой духовке в течение прибл. 30 минут при 180°С",
                            LanguageCode = "ru-RU"
                        },
                        new PizzaContent
                        {
                            Name = "Hawaiian Pizza",
                            Description = "Crumble the yeast and mix with water. Add the sugar, 2-3 tablespoons of flour and let stand for 10 minutes. In a large bowl, mix the rest of the flour with the salt. Leaven add to the flour together with the oil. Knead until smooth. Cover the dough with a cloth and let stand for 40 minutes in a warm place. Cake put on the largest sheet smeared with grease. Spread with tomato sauce. Sprinkle with oregano and basil. Place the slices of ham, sliced or diced pineapple and sprinkle with grated cheese. Bake in preheated oven for approx. 30 minutes at 180°C.",
                            LanguageCode = "en-GB"
                        },
                    }
                },
                new Pizza
                {
                    Price = 32.00,
                    ImageUrl = "http://www.kuchnia-domowa.pl/images/content/97/pizza_peperoni_3.jpg",
                    Contents = new[]
                    {
                        new PizzaContent
                        {
                            Name = "辣香肠比萨饼",
                            Description = "弄碎酵母和与水混合。加了糖，面粉几勺，静置10分钟。在一个大碗里，拌上盐面粉的其余部分。酵与油一起加入到面粉。揉至光滑。用一块布盖住面团，静置在一个温暖的地方40分钟。洋葱切成立方体和zezłocić上的油一汤匙。把面团在烤盘上涂有油脂或烤纸衬里。传播与番茄酱。牛至，盐，胡椒粉，蒜泥丁香和洋葱撒上。将香肠，番茄，切片香肠，辣椒，玉米片棒。用磨碎的奶酪撒。在180℃下烘烤在预热的烘箱中约30分",
                            LanguageCode = "zh-CN"
                        },
                        new PizzaContent
                        {
                            Name = "Pepperoni-Pizza",
                            Description = "Crumble die Hefe und mit Wasser mischen. Fügen Sie den Zucker, ein paar Esslöffel Mehl und lassen Sie stehen für 10 Minuten. In einer großen Schüssel mischen den Rest des Mehls mit dem Salz. Sauerteig fügen mit dem Öl zum Mehl zusammen. Kneten, bis glatt. Den Teig mit einem Tuch und lassen für 40 Minuten an einem warmen Ort stehen. Zwiebeln in Würfel schneiden und zezłocić auf einem Löffel Öl. Den Teig auf das Backblech mit Fett verschmiert oder mit Backpapier ausgekleidet. Verbreiten Sie mit Tomatensauce . Streuen mit Oregano, Salz, Pfeffer, zerdrückten Knoblauchzehen und Zwiebeln. Legen Sie die Scheiben Salami, Tomaten, in Scheiben geschnitten Peperoni, Paprika, Maiskolben . Mit geriebenem Käse. Im vorgeheizten Ofen ca. 30 Min. Bei 180°C",
                            LanguageCode = "de-DE"
                        },
                        new PizzaContent
                        {
                            Name = "Pepperoni Pizza",
                            Description = "Émietter la levure et mélanger avec de l'eau. Ajouter le sucre, quelques cuillères à soupe de farine et laisser reposer pendant 10 minutes. Dans un grand bol, mélanger le reste de la farine avec le sel. Levain ajouter à la farine conjointement avec l'huile. Pétrir jusqu'à consistance lisse. Couvrir la pâte avec un torchon et laisser reposer pendant 40 minutes dans un endroit chaud. Oignons coupés en cubes et zezłocić sur une cuillère d'huile. Mettre la pâte sur la plaque de cuisson enduite de graisse ou recouverte de papier de cuisson. Étaler la sauce tomate. Saupoudrer d'origan, le sel, le poivre, les gousses d'ail écrasées et l'oignon. Placer les tranches de salami, tomate, pepperoni tranché, poivrons, maïs en épi. Saupoudrer de fromage râpé. Cuire dans un four préchauffé pendant env. 30 minutes à 180°C",
                            LanguageCode = "fr-FR"
                        }
                    }
                },
                new Pizza
                {
                    Price = 29.00,
                    ImageUrl = "http://www.kuchnia-domowa.pl/images/content/308/calzone.jpg",
                    Contents = new[]
                    {
                        new PizzaContent
                        {
                            Name = "Calzone",
                            Description = "Préparer le gâteau. Farine, huile, sel, levure et 150ml d'eau chaude pour pétrir l'uniforme de la pâte. Mettez de côté dans un endroit chaud à monter pendant 45 minutes. Tomates verser sur l'eau bouillante, laisser pendant un certain temps, enlever la peau et les couper en cubes. Fromage Mozzarella coupé en tranches. Salami coupé en cubes. Lorsque la pâte divisée en 4 parties. Chaque partie du déploiement gâteau assez mince sous la forme d'un cercle. Demis répartis à la sauce tomate, en laissant une distance du rivage. Saupoudrer de sel à base de plantes. Mettez salami, tomates et fromage mozzarella. Plier la pâte en deux et coller soigneusement les bords. Cuire au four préchauffé pendant env. 25 minutes à 220°C (chauffe-haut-bas). Après 10 minutes de cuisson saupoudrer de fromage râpé.",
                            LanguageCode = "fr-FR"
                        },
                        new PizzaContent
                        {
                            Name = "Calzone",
                            Description = "Prepare the cake. Flour, oil, salt, yeast and 150ml of warm water to knead the dough uniform. Set aside in a warm place to rise for 45 minutes. Tomatoes pour over boiling water, leave for a while, remove the skin and cut into cubes. Mozzarella cheese cut into slices. Salami cut into cubes. When dough divided into 4 parts. Each part of the roll out fairly thin cake in the shape of a circle. Halves spread with tomato sauce, leaving a distance from the shore. Sprinkle with herbal salt. Put salami, tomatoes and mozzarella cheese. Fold the dough in half and glue the edges carefully. Bake in preheated oven for approx. 25 minutes at 220 ° C (heater up-down). After 10 minutes of baking sprinkle top with grated cheese.",
                            LanguageCode = "en-GB"
                        },
                    }
                },
            };

            collection.InsertMany(pizzaList);
        }
    }
}


//db.getCollection('pizza').insert([
//{
//    "_id" : ObjectId("57e697257ae46124486316c9"),
//    "Price" : 24.5,
//    "ImageUrl" : "http://www.kuchnia-domowa.pl/images/content/232/2.jpg",
//    "Contents" : [
//        {
//            "Name" : "Pizza Margherita",
//            "Description" : "Mąkę, olej, sól, drożdże i 150ml ciepłej wody zagnieść na jednolite ciasto. Odstawić w ciepłe miejsce do wyrośnięcia na 45 minut. Wyrośnięte ciasto podzielić na pół. Na dwóch blachach wyłożonych papierem do pieczenia uformować z ciasta placek w kształcie koła. Pizze posmarować sosem pomidorowym. Przyprawić solą. Mozzarellę osuszyć i pokroić w plasterki. Razem z listkami bazylii ułożyć na pizzy. Skropić oliwą. Każdą blachę piec w nagrzanym piekarniku ok. 20 minut w temperaturze 220°C",
//            "LanguageCode" : "pl-PL"
//        }, 
//        {
//            "Name" : "Pizza Margherita",
//            "Description" : "Flour, oil, salt, yeast and 150ml of warm water to knead the dough uniform. Set aside in a warm place to rise for 45 minutes. When dough divide in half. Two pans lined with parchment paper formed into a cake dough in the shape of a circle. Pizzas spread with tomato sauce. Season with salt. Mozzarella dry and cut into slices. Together with basil leaves lay on the pizza. Drizzle with olive oil. Each sheet bake in preheated oven for approx. 20 minutes at 220°C",
//            "LanguageCode" : "en-GB"
//        }
//    ]
//},
//{
//    "_id" : ObjectId("57e697257ae46124486316ca"),
//    "Price" : 27.0,
//    "ImageUrl" : "http://www.kuchnia-domowa.pl/images/content/96/pizza_hawajska_2.jpg",
//    "Contents" : [
//        {
//            "Name" : "Pizza Hawajska",
//            "Description" : "Drożdże pokruszyć i wymieszać z wodą. Dodać cukier, 2-3 łyżki mąki i odstawić na 10 minut. W dużej misce wymieszać resztę mąki z solą. Zaczyn dodać do mąki razem z olejem. Wyrobić na gładką masę. Ciasto przykryć ściereczką i odstawić na 40 minut w ciepłe miejsce. Ciasto wyłożyć na największą blachę posmarowaną tłuszczem. Posmarować sosem pomidorowym. Posypać oregano i bazylią. Nałożyć plastry szynki, plastry lub pokrojonego w kostkę ananasa i posypać startym serem. Piec w nagrzanym piekarniku ok. 30minut w temperaturze 180°C.",
//            "LanguageCode" : "pl-PL"
//        }, 
//        {
//            "Name" : "Гавайский Pizza",
//            "Description" : "Раскрошить дрожжи и смешать с водой. Добавьте сахар, 2-3 столовые ложки муки и дать постоять 10 минут. В большой миске смешайте оставшуюся часть муки с солью. Закваске добавить в муку вместе с маслом. Месить до получения однородной массы. Накройте тесто салфеткой и дать постоять 40 минут в теплом месте. Торт поставить на самый большой лист смазывают смазкой. Спред с томатным соусом. Посыпать орегано и базилик. Поместите ломтики ветчины, нарезанный или нарезанный кубиками ананас и посыпать тертым сыром. Выпекать в предварительно разогретой духовке в течение прибл. 30 минут при 180°С",
//            "LanguageCode" : "ru-RU"
//        }, 
//        {
//            "Name" : "Hawaiian Pizza",
//            "Description" : "Crumble the yeast and mix with water. Add the sugar, 2-3 tablespoons of flour and let stand for 10 minutes. In a large bowl, mix the rest of the flour with the salt. Leaven add to the flour together with the oil. Knead until smooth. Cover the dough with a cloth and let stand for 40 minutes in a warm place. Cake put on the largest sheet smeared with grease. Spread with tomato sauce. Sprinkle with oregano and basil. Place the slices of ham, sliced or diced pineapple and sprinkle with grated cheese. Bake in preheated oven for approx. 30 minutes at 180°C.",
//            "LanguageCode" : "en-GB"
//        }
//    ]
//},
//{
//    "_id" : ObjectId("57e697257ae46124486316cb"),
//    "Price" : 32.0,
//    "ImageUrl" : "http://www.kuchnia-domowa.pl/images/content/97/pizza_peperoni_3.jpg",
//    "Contents" : [
//        {
//            "Name" : "辣香肠比萨饼",
//            "Description" : "弄碎酵母和与水混合。加了糖，面粉几勺，静置10分钟。在一个大碗里，拌上盐面粉的其余部分。酵与油一起加入到面粉。揉至光滑。用一块布盖住面团，静置在一个温暖的地方40分钟。洋葱切成立方体和zezłocić上的油一汤匙。把面团在烤盘上涂有油脂或烤纸衬里。传播与番茄酱。牛至，盐，胡椒粉，蒜泥丁香和洋葱撒上。将香肠，番茄，切片香肠，辣椒，玉米片棒。用磨碎的奶酪撒。在180℃下烘烤在预热的烘箱中约30分",
//            "LanguageCode" : "zh-CN"
//        }, 
//        {
//            "Name" : "Pepperoni-Pizza",
//            "Description" : "Crumble die Hefe und mit Wasser mischen. Fügen Sie den Zucker, ein paar Esslöffel Mehl und lassen Sie stehen für 10 Minuten. In einer großen Schüssel mischen den Rest des Mehls mit dem Salz. Sauerteig fügen mit dem Öl zum Mehl zusammen. Kneten, bis glatt. Den Teig mit einem Tuch und lassen für 40 Minuten an einem warmen Ort stehen. Zwiebeln in Würfel schneiden und zezłocić auf einem Löffel Öl. Den Teig auf das Backblech mit Fett verschmiert oder mit Backpapier ausgekleidet. Verbreiten Sie mit Tomatensauce . Streuen mit Oregano, Salz, Pfeffer, zerdrückten Knoblauchzehen und Zwiebeln. Legen Sie die Scheiben Salami, Tomaten, in Scheiben geschnitten Peperoni, Paprika, Maiskolben . Mit geriebenem Käse. Im vorgeheizten Ofen ca. 30 Min. Bei 180°C",
//            "LanguageCode" : "de-DE"
//        }, 
//        {
//            "Name" : "Pepperoni Pizza",
//            "Description" : "Émietter la levure et mélanger avec de l'eau. Ajouter le sucre, quelques cuillères à soupe de farine et laisser reposer pendant 10 minutes. Dans un grand bol, mélanger le reste de la farine avec le sel. Levain ajouter à la farine conjointement avec l'huile. Pétrir jusqu'à consistance lisse. Couvrir la pâte avec un torchon et laisser reposer pendant 40 minutes dans un endroit chaud. Oignons coupés en cubes et zezłocić sur une cuillère d'huile. Mettre la pâte sur la plaque de cuisson enduite de graisse ou recouverte de papier de cuisson. Étaler la sauce tomate. Saupoudrer d'origan, le sel, le poivre, les gousses d'ail écrasées et l'oignon. Placer les tranches de salami, tomate, pepperoni tranché, poivrons, maïs en épi. Saupoudrer de fromage râpé. Cuire dans un four préchauffé pendant env. 30 minutes à 180°C",
//            "LanguageCode" : "fr-FR"
//        }
//    ]
//},
//{
//    "_id" : ObjectId("57e697257ae46124486316cc"),
//    "Price" : 29.0,
//    "ImageUrl" : "http://www.kuchnia-domowa.pl/images/content/308/calzone.jpg",
//    "Contents" : [
//        {
//            "Name" : "Calzone",
//            "Description" : "Préparer le gâteau. Farine, huile, sel, levure et 150ml d'eau chaude pour pétrir l'uniforme de la pâte. Mettez de côté dans un endroit chaud à monter pendant 45 minutes. Tomates verser sur l'eau bouillante, laisser pendant un certain temps, enlever la peau et les couper en cubes. Fromage Mozzarella coupé en tranches. Salami coupé en cubes. Lorsque la pâte divisée en 4 parties. Chaque partie du déploiement gâteau assez mince sous la forme d'un cercle. Demis répartis à la sauce tomate, en laissant une distance du rivage. Saupoudrer de sel à base de plantes. Mettez salami, tomates et fromage mozzarella. Plier la pâte en deux et coller soigneusement les bords. Cuire au four préchauffé pendant env. 25 minutes à 220°C (chauffe-haut-bas). Après 10 minutes de cuisson saupoudrer de fromage râpé.",
//            "LanguageCode" : "fr-FR"
//        }, 
//        {
//            "Name" : "Calzone",
//            "Description" : "Prepare the cake. Flour, oil, salt, yeast and 150ml of warm water to knead the dough uniform. Set aside in a warm place to rise for 45 minutes. Tomatoes pour over boiling water, leave for a while, remove the skin and cut into cubes. Mozzarella cheese cut into slices. Salami cut into cubes. When dough divided into 4 parts. Each part of the roll out fairly thin cake in the shape of a circle. Halves spread with tomato sauce, leaving a distance from the shore. Sprinkle with herbal salt. Put salami, tomatoes and mozzarella cheese. Fold the dough in half and glue the edges carefully. Bake in preheated oven for approx. 25 minutes at 220 ° C (heater up-down). After 10 minutes of baking sprinkle top with grated cheese.",
//            "LanguageCode" : "en-GB"
//        }
//    ]
//}
//])