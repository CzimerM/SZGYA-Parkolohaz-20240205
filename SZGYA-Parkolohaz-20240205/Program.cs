using System;
using System.Text;

namespace SZGYA_Parkolohaz_20240205
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Emelet> emeletek = new List<Emelet>();

            var sr = new StreamReader("../../../src/parkolohaz.txt", Encoding.UTF8);
            for (int i = 1; !sr.EndOfStream; i++)
            {
                emeletek.Add(new Emelet(i, sr.ReadLine()));
            }
            sr.Close();

            foreach (var emelet in emeletek)
            {
                Console.WriteLine(emelet);
            }

            //8 
            Console.WriteLine($"\n8.feladat {emeletek.MinBy(e => e.Szektorok.Sum()).Nev}");

            //9
            Console.WriteLine($"\n9.feladat: {emeletek.FirstOrDefault(e => e.Szektorok.Contains(0))}");
        }
    }
}
