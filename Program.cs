namespace Reseloggen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Resor.LoadList();

            Menu.MainMenu();
            Menu.ExitMenu();

            Resor.SaveList();

            Console.Clear();
            Console.WriteLine("Välkommen åter!");
            Console.WriteLine("Tryck på valfri tangent för att avsluta programmet...");
            Console.ReadKey();
        }
    }
    
}
