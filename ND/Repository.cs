using ND.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ND
{
    public class FruitRepository
    {
        private readonly IFruitDataProvider m_provider;
        public FruitRepository(IFruitDataProvider provider)
        {
            m_provider = provider;
        }
        public int FruitCountFamily(string family)

        {
            //suskaiciuoja kiek kaloriju turi vienos seimos vaisiai
            //calories = m_provider.GetRecentFruitsOfFamily(family).Sum(o => o.nutritions.calories);
            return m_provider.GetRecentFruitsOfFamily(family).Sum(o => o.nutritions.calories);

        }
        public Root FruitProtein(string genus)

        {
            //suskaiciuoja max proteinu turinti is genus
            Root max = null;
            foreach(var o in m_provider.GetRecentFruitsOfGenus(genus))
            {
                if (max == null || max.nutritions.protein <= o.nutritions.protein)
                    max = o;
            }
            
            return max;

        }
        public Root FruitSugar(string name)

        {
            //suskaiciuoja max is visu sugar turinti
            Root max = null;
            foreach (var o in m_provider.GetRecentFruits(name))
            {
                if (max == null || max.nutritions.sugar <= o.nutritions.sugar)
                    max = o;
            }

            return max;

        }
    }
}
