namespace Reseloggen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> reseLista = new List<string>();
            bool runMenu = true;

            while (runMenu)
            {
                Console.WriteLine("1. Lägg till resmål i reseloggen");
                Console.WriteLine("2. Ta bort resmål från reseloggen");
                Console.WriteLine("3. Visa reseloggen");
                Console.WriteLine("4. Rensa reseloggen");
                Console.WriteLine("0. Avsluta Program");
                Console.WriteLine("Skriv in siffra för ditt val");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    Console.WriteLine("Lägg till resmål: ");
                    string nyResa = Console.ReadLine();
                    reseLista.Add(nyResa);
                }
                else if (choice == "2")
                {
                    Console.WriteLine("Ta bort resmål via index ");
                    int index = int.Parse(Console.ReadLine());
                    int removeIndex = index - 1;
                    reseLista.RemoveAt(removeIndex);
                }
                else if (choice == "3")
                {
                    Console.WriteLine("Visa resmål i listan: ");
                    for (int i = 0; i < reseLista.Count; i++)
                    {
                        int index = i + 1;
                        Console.WriteLine($"{index}. {reseLista[i]}");
                    }
                }
                else if (choice == "4")
                {
                    Console.WriteLine("Rensa reseloggen: ");
                    reseLista.Clear();
                }
                else if (choice == "0")
                {
                    Console.WriteLine("Programmet avslutas");
                    Console.ReadKey();
                    runMenu = false;
                }
            }
            //MyMethod(int i);

            //static int MyMethod(int i)
            //{
            //    return i;
            //}
        }
    }
    
}
