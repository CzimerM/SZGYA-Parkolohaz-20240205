using System.Text.Json;
using System.Text;

namespace HaladoFileGenerator
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Dictionary<int, List<Emelet>> parkolohazAdatok = new Dictionary<int, List<Emelet>>();

            string[] parkoloEmeletek = File.ReadAllLines("../../../src/emeletek.txt");

            for (int i = 6; i <= 24; i++)
            {
                parkolohazAdatok.Add(i, new List<Emelet>());
                for (int j = 0; j < parkoloEmeletek.Length; j++)
                {
                    
                    List<int> parkoloAutok = new List<int>();
                    for (int k = 0; k < 6; k++)
                    {
                        parkoloAutok.Add(rnd.Next(0, 16));
                    }
                    parkolohazAdatok[i].Add(new Emelet(j + 1, parkoloEmeletek[j], parkoloAutok));
                }                
            }

            StreamWriter sw = new StreamWriter("../../../src/parkolo.json", false, Encoding.UTF8);
            sw.WriteLine(JsonSerializer.Serialize(parkolohazAdatok));
            sw.Close();
        }
    }
}
