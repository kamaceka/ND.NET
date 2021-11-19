using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibrary1
{
    public class Preke
    {
        public string Name;
        public decimal Kaina;
        public string Kategorija;

        public override string ToString()
        {
            return $"{Name} ({Kategorija}):{Kaina}";
        }
    }
    public class Pirkinys
    {
        public int Id;
        public DateTime Data;
        public IEnumerable<Preke> Prekes;
        public decimal Kaina => Prekes.Sum(p => p.Kaina);
        public decimal Kiekis => Prekes.Count();

    }
    public class ManoPirkiniai
    {
        void Prideti(Pirkinys pirk)
        {

        }
        public IEnumerable<Pirkinys> Surasti(DateTime date)
        {
            return new List<Pirkinys>()
            {
                new Pirkinys()
                {
                    Id=1,
            Data = new DateTime(date.Year, date.Month, date.Day, 12, 0, 0),
            Prekes=new Preke[]
            {
                new Preke{Kaina=1.00m,Kategorija ="maistas", Name="duona"},
                new Preke{Kaina=2.00m,Kategorija ="maistas", Name="salotos"},
                new Preke{Kaina=1.50m,Kategorija ="gerimai", Name="cola"}
            }

                },
                new Pirkinys()
                {
                    Id=2,
            Data = new DateTime(date.Year, date.Month, date.Day, 12, 30, 0),
            Prekes=new Preke[]
            {
                new Preke{Kaina=5.00m,Kategorija ="maistas", Name="duona"},
                new Preke{Kaina=20.00m,Kategorija ="gerimas", Name="pepsi"},
                new Preke{Kaina=13.50m,Kategorija ="gerimai", Name="cola"}
            }

                },
                new Pirkinys()
                {
                    Id=3,
            Data = new DateTime(date.Year, date.Month, date.Day, 16, 30, 0),
            Prekes=new Preke[]
            {
                new Preke{Kaina=56.00m,Kategorija ="maistas", Name="duona"},
                new Preke{Kaina=34.00m,Kategorija ="maistas", Name="salotos"},
                new Preke{Kaina=21.50m,Kategorija ="gerimai", Name="cola"}
            }

                }
            };
            
        }
    }
}
