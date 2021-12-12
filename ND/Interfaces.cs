using ND.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ND
{
    public interface IFruitDataProvider
    {
        List<Root> GetRecentFruits(string name);
        List<Root> GetRecentFruitsOfFamily(string family);
        List<Root> GetRecentFruitsOfGenus(string genus);
        List<Root> GetRecentSugaryFruits(double sugar);
        
    }
}
