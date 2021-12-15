using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;
using ND ;

using System.Collections.Generic;
using ND.Models;

namespace MoqTestas
{
    //edited
    [TestClass]
    public class UnitTest1 
    {
        [TestMethod]
        public void TestFruitCount()
        {

            var provider = new Mock<FruitDataProvider>(MockBehavior.Strict);
            provider.Setup(m => m.GetRecentFruitsOfFamily("Rosaceae"))
                .Returns(new List<Root> {
                        new Root {genus= "Diospyros",
                    name= "Persimmon",
                    id= 52,
                    family= "Rosaceae",
                    order= "Rosales",
                    nutritions = new Nutritions { carbohydrates = 28, protein = 30, fat = 40, calories = 84, sugar = 28 } },
                        new Root {genus= "Difffffos",
                    name= "Pgggggn",
                    id= 54,
                    family= "Rosaceae",
                    order= "Rosales",
                    nutritions = new Nutritions { carbohydrates = 18, protein = 0, fat = 0, calories = 81, sugar = 18 } },
                        new Root {genus= "Diospyros",
                    name= "Pkkkkkk",
                    id= 526,
                    family= "Rosaceae",
                    order= "Rosales",
                    nutritions = new Nutritions { carbohydrates = 118, protein = 50, fat = 30, calories = 41, sugar = 18 } },
                        new Root{genus= "Diospyros",
                    name= "KKKFFFon",
                    id= 22,
                    family= "Rosaceae",
                    order= "Rosales",
                    nutritions = new Nutritions { carbohydrates = 38, protein = 0, fat = 10, calories = 71, sugar = 48 } },
                        new Root {genus= "TTTGGGGs",
                    name= "LAbas",
                    id= 34,
                    family= "Rosaceae",
                    order= "Rosales",
                    nutritions = new Nutritions { carbohydrates = 13, protein = 50, fat = 0, calories = 31, sugar = 8 } },
                        new Root {
                            genus = "Dfff",
                            name = "KAzkasn",
                            id = 50,
                            family = "Rosaceae",
                            order = "Rosales",
                            nutritions = new Nutritions { carbohydrates = 0, protein = 29, fat = 47, calories = 29, sugar = 78 }
                        }
                });

            provider.Setup(m =>
                m.GetRecentFruitsOfFamily("Rosaceae"))
                    .Returns(new List<Root>());

            

            

            //Jei atkomentuosiu, VerifyAll() sufeilins, nes sito metodo testas nekviecia
            //provider.Setup(m => m.GetRecentObservations(It.IsAny<string>()))
            //    .Verifiable();

            var repository = new FruitRepository(provider.Object);

            Assert.AreEqual(44, repository.FruitCountFamily("Rosaceae"));
            Assert.AreEqual(0, repository.FruitCountFamily("Rosaceae"));
            Assert.AreEqual(26, repository.FruitCountFamily("Rosaceae"));
            Assert.AreEqual(26, repository.FruitCountFamily("Rosaceae"));
            Assert.AreEqual(1, repository.FruitCountFamily("Rosaceae"));
            Assert.AreEqual(0, repository.FruitCountFamily("Rosaceae"));

            provider.VerifyAll();

        }

        [TestMethod]
        public void TestBiggestProtein()
        {
            var data = new List<Root>
            {
                 new Root {genus = "Diospyros",
                            name = "KAzkasn",
                            id = 50,
                            family = "Rosaceae",
                            order = "Rosales",
                            nutritions = new Nutritions { carbohydrates = 0, protein = 29, fat = 47, calories = 29, sugar = 78 }},
                 new Root {genus = "Diospyros",
                            name = "KAzkasn",
                            id = 50,
                            family = "Rosaceae",
                            order = "Rosales",
                            nutritions = new Nutritions { carbohydrates = 0, protein = 9, fat = 47, calories = 29, sugar = 78 }},
                 new Root {genus ="Diospyros",
                            name = "KAzkasn",
                            id = 50,
                            family = "Rosaceae",
                            order = "Rosales",
                            nutritions = new Nutritions { carbohydrates = 0, protein = 2, fat = 47, calories = 29, sugar = 78 }},
                 new Root {genus = "Diospyros",
                            name = "KAzkasn",
                            id = 50,
                            family = "Rosaceae",
                            order = "Rosales",
                            nutritions = new Nutritions { carbohydrates = 0, protein = 19, fat = 47, calories = 29, sugar = 78 }},
                 new Root {genus = "Diospyros",
                            name = "KAzkasn",
                            id = 50,
                            family = "Rosaceae",
                            order = "Rosales",
                            nutritions = new Nutritions { carbohydrates = 0, protein = 3, fat = 47, calories = 29, sugar = 78 }},
                 new Root {genus ="Diospyros",
                            name = "KAzkasn",
                            id = 50,
                            family = "Rosaceae",
                            order = "Rosales",
                            nutritions = new Nutritions { carbohydrates = 0, protein = 59, fat = 47, calories = 29, sugar = 78 }},
                new Root {genus = "Diospyros",
                            name = "KAzkasn",
                            id = 50,
                            family = "Rosaceae",
                            order = "Rosales",
                            nutritions = new Nutritions { carbohydrates = 0, protein = 26, fat = 47, calories = 29, sugar = 78 }},
            };
            var provider = new Mock<IFruitDataProvider>(MockBehavior.Strict);
            var repository = new FruitRepository(provider.Object);

            provider.Setup(m => m.GetRecentFruitsOfGenus("Diospyros"))
                .Returns(new List<Root> {
                    new Root {genus = "Diospyros",
                            name = "KAzkasn",
                            id = 50,
                            family = "Rosaceae",
                            order = "Rosales",
                            nutritions = new Nutritions { carbohydrates = 0, protein = 26, fat = 47, calories = 29, sugar = 78 }},
                    new Root {genus = "Diospyros",
                            name = "KAzkasn",
                            id = 50,
                            family = "Rosaceae",
                            order = "Rosales",
                            nutritions = new Nutritions { carbohydrates = 0, protein = 36, fat = 47, calories = 29, sugar = 78 }},
                    new Root {genus = "Diospyros",
                            name = "KAzkasn",
                            id = 50,
                            family = "Rosaceae",
                            order = "Rosales",
                            nutritions = new Nutritions { carbohydrates = 0, protein = 16, fat = 47, calories = 29, sugar = 78 }},
                    new Root {genus = "Diospyros",
                            name = "KAzkasn",
                            id = 50,
                            family = "Rosaceae",
                            order = "Rosales",
                            nutritions = new Nutritions { carbohydrates = 0, protein = 22, fat = 47, calories = 29, sugar = 78 }},
                    new Root {genus = "Diospyros",
                            name = "KAzkasn",
                            id = 50,
                            family = "Rosaceae",
                            order = "Rosales",
                            nutritions = new Nutritions { carbohydrates = 0, protein = 24, fat = 47, calories = 29, sugar = 78 }},
                  new Root {genus = "Diospyros",
                            name = "KAzkasn",
                            id = 50,
                            family = "Rosaceae",
                            order = "Rosales",
                            nutritions = new Nutritions { carbohydrates = 0, protein = 29, fat = 47, calories = 29, sugar = 78 }},
                    new Root {genus ="Diospyros",
                            name = "KAzkasn",
                            id = 50,
                            family = "Rosaceae",
                            order = "Rosales",
                            nutritions = new Nutritions { carbohydrates = 0, protein = 38, fat = 47, calories = 29, sugar = 78 }},
                });

            provider.Setup(m => m.GetRecentFruitsOfGenus("Diospyros"))
                .Returns(new List<Root>());

            

            var obs = repository.FruitProtein("Diospyros");
            Assert.AreEqual(100, obs.nutritions.protein);
            

            Assert.IsNull(repository.FruitProtein("Diospyros"));

            obs = repository.FruitProtein("Diospyros");
            Assert.AreEqual(58, obs.nutritions.protein);
            

            obs = repository.FruitProtein("Diospyros");
            Assert.AreEqual(234, obs.nutritions.protein);
           

            provider.VerifyAll();
        
    }
    }
}
