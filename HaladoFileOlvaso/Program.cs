using HaladoFileGenerator;
using System.Text.Json;

namespace HaladoFileOlvaso
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, List<Emelet>> parkolohazAdatok = new Dictionary<int, List<Emelet>>();
            string jsonString = File.ReadAllText("../../../../HaladoFileGenerator/src/parkolo.json");
            parkolohazAdatok = JsonSerializer.Deserialize<Dictionary<int, List<Emelet>>>(jsonString);

            foreach (var p in parkolohazAdatok)
            {
                Console.WriteLine($"{p.Key} óra");
                foreach (var item in p.Value) 
                {
                    Console.WriteLine($"\t{item}");
                }
            }

            //1
            Console.WriteLine($"\n1.feladat: {parkolohazAdatok.MaxBy(p => p.Value.Sum(e => e.Szektorok.Sum())).Key} órakkor");

            //2
            Console.WriteLine($"\n2.feladat: {parkolohazAdatok.Last().Value.Sum(e => e.Szektorok.Sum())} autó maradt");

            //3

        }
    }
}
