using Microsoft.VisualStudio.TestTools.UnitTesting;
using ND;
using ND.Models;

using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System;

namespace UnitTestProject1
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
            return m_data;

        }

        public List<Root> GetRecentFruitsOfFamily(string family)
        {
            //gal klaida nes reik IEnumerable
            var result = m_data.Where(o => o.family == family);
            return (List<Root>)result; //.AsEnumerable()

        }

        public List<Root> GetRecentSugaryFruits(double sugar)
        {
            return m_data;
        }
    }
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCaloriesCount()
        {
           
            var data = new List<Root>()
            {
               new Root {

                   family= "Rosaceae",
                    nutritions= {
                        calories= 81
                        }}
               /*
                  new Root {genus= "Diospyros",
                    name= "Persimmon",
                    id= 52,
                    family= "Ebenaceae",
                    order= "Rosales",
                    nutritions= { carbohydrates= 18,
                        protein= 0,
                        fat= 0,
                        calories= 81,
                        sugar= 18 } },
                     new Root {genus= "Diospyros",
                    name= "Persimmon",
                    id= 52,
                    family= "Ebenaceae",
                    order= "Rosales",
                    nutritions= { carbohydrates= 18,
                        protein= 0,
                        fat= 0,
                        calories= 81,
                        sugar= 18 } }*/

        };


            var provider = new FakeProvider(data);
            var repository = new FruitRepository(provider);

            Assert.AreEqual(81, repository.FruitCountFamily("Rosaceae"));
        }
        [TestMethod]
        public void TestBiggestProtein()
        {
            //Moq
            var data = new List<Root>()
            {
               

                  
               
                  new Root {genus= "Diospyros",
                    name= "Persimmon",
                    id= 52,
                    family= "Ebenaceae",
                    order= "Rosales",
                    nutritions= { carbohydrates= 18,
                        protein= 0,
                        fat= 0,
                        calories= 81,
                        sugar= 18 } },
                     new Root {genus= "Diospyros",
                    name= "Banana",
                    id= 52,
                    family= "Ebenaceae",
                    order= "Rosales",
                    nutritions= { carbohydrates= 18,
                        protein= 3,
                        fat= 0,
                        calories= 81,
                        sugar= 18 } }

        };


            var provider = new FakeProvider(data);
            var repository = new FruitRepository(provider);

            var max = repository.FruitProtein("banana");
            Assert.AreEqual(data[0], max);
            Assert.IsNull(max);
            Assert.AreEqual(data[1], max);
        }
    }
}
