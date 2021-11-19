using System;
using System.Collections. Generic;
using System.Linq;

namespace MyLibrary1
{
    public class Prekes
    {
        public string Name;
        public decimal Kaina;
        public string Kategorija;

    }
    public class Pirkinys
    {
        int Id;
        public DateTime Data;
        IEnumerable<Prekes> Prekes;

        decimal Kaina => Prekes.Sum(p => p.Kaina);

    }
    public class ManoPirkiniai
    {
        void Prideti(Pirkinys pirk)
        {

        }

        IEnumerable<Pirkinys> Surasti(DateTime date)
        {
            return new Pirkinys[0];
        }
    }

}
