using ND;
using ND.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System;
using Moq;

namespace UnitTestProject2
{
    
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestCaloriesCountLooseMock()
        {
            var provider = new Mock<IFruitDataProvider>();
            var repository = new FruitRepository(provider.Object);
            repository.FruitCountFamily("Rosaceae");
            provider.Verify(x => x.GetRecentFruitsOfFamily("Rosaceae"), Times.Once());

            repository.FruitCountFamily("Rosaceae");
            provider.Verify(x => x.GetRecentFruitsOfFamily("Rosaceae"), Times.Once());

            repository.FruitCountFamily("Kazkas");
            provider.Verify(x => x.GetRecentFruitsOfFamily("Rosaceae"), Times.Once());
            
            
            //pakeiciau 
            //var provider = new FakeProvider(data);
            
            
            //kadangi moqina random family, kurios nera duomenyse, neveikia moq
            Assert.AreEqual(285, repository.FruitCountFamily(""));
            provider.Verify(x => x.GetRecentFruitsOfFamily("Rosaceae"), Times.Once()); //viena karta iskviestas
            Assert.AreEqual(285, repository.FruitCountFamily("Ebenaceae"));
            provider.Verify(x => x.GetRecentFruitsOfFamily("Rosaceae"), Times.Once()); //viena karta iskviestas
        }
        [TestMethod]
        public void TestCaloriesCountStrictMock()
        {

            var provider = new Mock<IFruitDataProvider>(MockBehavior.Strict);
            



            provider.Setup(m => m.GetRecentFruitsOfFamily("Diospyros"))
                .Returns(new List<Root> {
                    new Root {genus = "Diospyros",
                            name = "KAzkasn",
                            id = 50,
                            family = "Rosaceae",
                            order = "Rosales",
                            nutritions = new Nutritions { carbohydrates = 0, protein = 26, fat = 47, calories = 29, sugar = 78 }},
                });

            provider.Setup(m => m.GetRecentFruitsOfFamily("Diospyros"))
                .Returns(new List<Root> {
                    new Root {genus = "Diospyros",
                            name = "KAzkasn",
                            id = 50,
                            family = "Rosaceae",
                            order = "Rosales",
                            nutritions = new Nutritions { carbohydrates = 0, protein = 26, fat = 47, calories = 29, sugar = 78 }},
                });

            var repository = new FruitRepository(provider.Object);

            

            repository.FruitCountFamily("Rosaceae");
            provider.Verify(x => x.GetRecentFruitsOfFamily("Rosaceae"), Times.Once());

            repository.FruitCountFamily("Rosaceae");
            provider.Verify(x => x.GetRecentFruitsOfFamily("Rosaceae"), Times.Once());

            repository.FruitCountFamily("Kazkas");
            provider.Verify(x => x.GetRecentFruitsOfFamily("Rosaceae"), Times.Once());


            //pakeiciau 
            //var provider = new FakeProvider(data);


            
            Assert.AreEqual(285, repository.FruitCountFamily("Rosaceae"));
            provider.Verify(x => x.GetRecentFruitsOfFamily("Rosaceae"), Times.Once()); //viena karta iskviestas
            Assert.AreEqual(285, repository.FruitCountFamily("Ebenaceae"));
            provider.Verify(x => x.GetRecentFruitsOfFamily("Rosaceae"), Times.Once()); //viena karta iskviestas
        }
    }
    
}