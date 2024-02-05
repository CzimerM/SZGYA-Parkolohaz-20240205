using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZGYA_Parkolohaz_20240205
{
    internal class Emelet
    {
        public int Szint { get; set; }
        public string Nev { get; set; }
        public List<int> Szektorok { get; set; }

        public Emelet(int szint, string sor) 
        {
            this.Szint = szint;
            this.Szektorok = new List<int>();
            string[] adatok = sor.Split("; ");
            this.Nev = adatok[0];
            for (int i = 1; i < adatok.Length; i++)
            {
                this.Szektorok.Add(int.Parse(adatok[i]));
            }
        }

        public override string ToString()
        {
            string str = $"{this.Szint,2}.szint|{Nev, 8}";
            foreach (var sz in this.Szektorok)
            {
                str += $"|{sz, 2}";
            }
            return str;
        }
    }
}
