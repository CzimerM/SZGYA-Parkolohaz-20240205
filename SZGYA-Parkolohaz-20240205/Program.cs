﻿using System;
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
            Console.WriteLine($"\n8.feladat: {emeletek.MinBy(e => e.Szektorok.Sum()).Nev}");

            //9
            Console.WriteLine("\n9.feladat");
            var nincs = emeletek.FindAll(e => e.Szektorok.Contains(0));
            if (nincs.Count == 0 ) Console.WriteLine("Nincs ilyen");
            nincs.ForEach(e => Console.WriteLine($"{e.Szint}.szint {e.Szektorok.Select((val, i) => (val, i)).First(e => e.val == 0).i + 1}.szektor"));
            

            //10
            var atlag = emeletek.Average(e => e.Szektorok.Average());
            Console.WriteLine($"\n10.feladat: \n\tÁtlag count: {emeletek.Sum(e => e.Szektorok.Count(i => i == atlag))}\n\tÁtlag alatti: {emeletek.Sum(e => e.Szektorok.Count(i => i < atlag))}\n\tÁtlag feletti: {emeletek.Sum(e => e.Szektorok.Count(i => i > atlag))}");

            //11
            Console.WriteLine("\n11.feladat");
            var sw = new StreamWriter("../../../src/egyauto.txt", false, Encoding.UTF8);
            emeletek.Where(e => e.Szektorok.Contains(1)).ToList().ForEach(i => sw.WriteLine($"{i.Szint}-{string.Join('-',i.Szektorok.Select((val, i) => (val,i)).Where(e => e.val == 1).Select(e => e.i + 1))}"));
            

            //12
            var legfelso = emeletek.Last();
            var max = emeletek.MaxBy(e => e.Szektorok.Sum());
            Console.WriteLine($"\n12.feladat: {(legfelso == max ? "igaz" :  $"hamis, a legtöbb a {max.Nev} emeleten van")}");

            //13
            Console.WriteLine("\n13.feladat");
            emeletek.ForEach(e => sw.WriteLine($"{e.Nev}: {e.Szektorok.Count * 15 - e.Szektorok.Sum()}"));
            sw.Close();

            //14
            Console.WriteLine($"\n14.feladat: {(emeletek.Count * emeletek.First().Szektorok.Count * 15) - (emeletek.Sum(e => e.Szektorok.Sum()))}");
        }
    }
}
