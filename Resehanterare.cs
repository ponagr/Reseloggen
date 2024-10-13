using System.Text.Json;
using System.Text.Json.Nodes;

namespace Reseloggen
{
    public class Resehanterare
    {
        public static List<Resor> reseLogg = new List<Resor>();

        public static void AddDestination()
        {
            while (true)
            {
                try
                {
                    Console.Write("\nSkriv in en plats du har besökt: ");
                    string place = Console.ReadLine();
                    if (place == "")
                    {
                        Console.WriteLine("Du måste fylla i en plats");
                        continue;
                    }
                    place = char.ToUpper(place[0]) + place.Substring(1).ToLower();
                    Console.Write("Skriv in året för besöket: ");
                    int year = int.Parse(Console.ReadLine());
                    if (year < 1900 || year > 2025)
                    {
                        Console.WriteLine("Skriv in ett år som är efter 1900 och före 2025");
                        continue;
                    }
                    Console.Write("Ge ett betyg mellan 1-5: ");
                    int grade = int.Parse(Console.ReadLine());
                    if (grade < 1 || grade > 5)
                    {
                        Console.WriteLine("Talet måste vara mellan 1-5");
                        continue;
                    }
                    Console.Write("Ge en beskrivning för platsen: ");
                    string description = Console.ReadLine();
                    if (description == "")
                    {
                        Console.WriteLine("Du måste fylla i en beskrivning");
                        continue;
                    }

                    reseLogg.Add(new Resor { Place = place, Description = description, Year = year, Grade = grade });
                    Console.WriteLine("Resan tillagd");
                    Console.ReadKey();
                    break;
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Något gick fel vid inmatningen");
                    throw;
                }
            }            
        }

        public static void PrintList()
        {
            Console.WriteLine();
            // foreach (Resor b in reseLogg)
            // {
            //     Console.WriteLine(b.ToString());
            // }
            if (reseLogg.Count < 1)
            {
                Console.WriteLine("Det finns inga resor tillagda än");
            }
            else
            {
                for (int i = 0; i < reseLogg.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {reseLogg[i].ToString()}");
                } 
            }
            Console.ReadKey();
        }
        


        // public static void SaveList()
        // {
        //     string fileName = "Resor.json";
        //     string jsonString = JsonSerializer.Serialize(reseLogg);
        //     File.WriteAllText(fileName, jsonString);
        // }
        // public static void LoadList()
        // {
        //     string fileName = "Resor.json";
        //     string jsonString = File.ReadAllText(fileName);
        //     reseLogg = JsonSerializer.Deserialize<List<Resor>>(jsonString);
        // }
    }
}