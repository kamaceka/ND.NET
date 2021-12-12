using Microsoft.VisualStudio.TestTools.UnitTesting;
using ND;
using ND.Models;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System;
using Moq;

namespace UnitTestProject2
{
    class FakeProvider : IFruitDataProvider
    {
        List<Root> m_data;


        public FakeProvider(List<Root> data)
        {
            m_data = data;
        }
        public List<Root> GetRecentFruits(string name)
        {
            return m_data.ToList();

        }

        public List<Root> GetRecentFruitsOfFamily(string family)
        {

           var result = m_data;
            return (List<Root>)result.ToList();

        }
        public List<Root> GetRecentFruitsOfGenus(string genus)
        {
            return m_data.ToList();
        }
        public List<Root> GetRecentSugaryFruits(double sugar)
        {
            return m_data.ToList();
        }
    }
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCaloriesCount()
        {
            /*
            var data = new List<Root>()
            {
               new Root {

                   family= "Rosaceae",
                    nutritions= new Nutritions { carbohydrates= 18,
                    protein= 0,
                    fat= 0,
                    calories= 81,
                    sugar= 18 } },


                  new Root {genus= "Diospyros",
                    name= "Persimmon",
                    id= 52,
                    family= "Rosaceae",
                    order= "Rosales",
                    nutritions = new Nutritions { carbohydrates = 18, protein = 0, fat = 0, calories = 81, sugar = 18 } },
                     new Root {genus= "Diospyros",
                    name= "Persimmon",
                    id= 52,
                    family= "Ebenaceae",
                    order= "Rosales",
                    nutritions= new Nutritions{ carbohydrates= 18,
                        protein= 0,
                        fat= 0,
                        calories= 81,
                        sugar= 18 } }

        };
            */
            //pakeiciau 
            //var provider = new FakeProvider(data);
            var provider = new Mock<IFruitDataProvider>();
            var repository = new FruitRepository(provider.Object);
            
            //kadangi moqina random family, kurios nera duomenyse, neveikia moq
            Assert.AreEqual(285, repository.FruitCountFamily(""));
            provider.Verify(x => x.GetRecentFruitsOfFamily("Rosaceae"), Times.Once()); //viena karta iskviestas
            Assert.AreEqual(285, repository.FruitCountFamily("Ebenaceae"));
            provider.Verify(x => x.GetRecentFruitsOfFamily("Rosaceae"), Times.Once()); //viena karta iskviestas
        }
    }
    
}