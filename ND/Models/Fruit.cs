using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ND.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Nutritions
    {
        public double carbohydrates { get; set; }
        public double protein { get; set; }
        public double fat { get; set; }
        public int calories { get; set; }
        public double sugar { get; set; }
    }
    public class Root
    {
        public string genus { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public string family { get; set; }
        public string order { get; set; }
        public Nutritions nutritions { get; set; }

        public override string ToString()
        {
            return $"{genus}; {name}; {id}; {family}; {order};" +
                $" {nutritions.carbohydrates}; {nutritions.protein};  {nutritions.fat}; {nutritions.calories}; {nutritions.sugar}";
        }

    }
    
    
    /*
     * "genus": "Fragaria",
"name": "Strawberry",
"id": 3,
"family": "Rosaceae",
"order": "Rosales",
"nutritions": {
  "carbohydrates": 5.5,
  "protein": 0,
  "fat": 0.4,
  "calories": 29,
  "sugar": 5.4
     */

}
