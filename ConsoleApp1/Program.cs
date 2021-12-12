using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ND;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //string name="Lemon";
            var provider = new FruitDataProvider();
            var results= provider.GetRecentFruits("all");
            var results1 = provider.GetRecentFruitsOfFamily("Rosaceae");
            var results2 = provider.GetRecentSugaryFruits(10);
            

            //grazina ka nors kita
            var repository = new FruitRepository(provider);
            Console.WriteLine(repository.FruitCountFamily("Rosaceae"));
            



            Console.ReadLine();
        }
    }
}
