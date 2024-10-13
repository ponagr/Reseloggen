using Reseloggen;

public static class Menu
{
    //Metod som kan användas av alla andra menyer för att minska Redundans.
    //Används för att kunna göra val i menyn via Piltangenter, Enter och Backspace
    public static int ShowMenu(string[] options)
    {
        int menuChoice = 0;
        bool runMenu = true;

        while (runMenu)
        {
            Console.Clear();
            Console.CursorVisible = false;

            for (int i = 0; i < options.Length; i++)
            {
                if (i == menuChoice)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;    //För att HighLighta nuvarande menyval med pil och textfärg
                    Console.WriteLine(options[i] + " <--");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(options[i]);  //Skriv ut resterande menyval utan pil och highlight
                }
            }

            var keyPressed = Console.ReadKey();

            if (keyPressed.Key == ConsoleKey.DownArrow && menuChoice < options.Length - 1)  //Om menyVal inte redan är på sista index , gå fram ett element
            {
                menuChoice++;
            }
            else if (keyPressed.Key == ConsoleKey.UpArrow && menuChoice > 0)    //Om menyVal inte redan är på index 0, gå tillbaka ett element
            {
                menuChoice--;
            }
            else if (keyPressed.Key == ConsoleKey.Enter)    //Välj nuvarande index
            {
                return menuChoice;
            }
            else if (keyPressed.Key == ConsoleKey.Backspace)    //Vid tryck på "Backspace", välj sista menyvalet(Avsluta/Gå Tillbaka)
            {
                return options.Length - 1;
            }
        }
        return -1;
    }

    public static int ShowRemoveMenu(string[] options)
    {
        int menuChoice = 0;
        bool runMenu = true;

        while (runMenu)
        {
            Console.Clear();
            Console.CursorVisible = false;

            for (int i = 0; i < options.Length; i++)
            {
                if (i == menuChoice)
                {
                    Console.ForegroundColor = ConsoleColor.Red;    //För att HighLighta nuvarande menyval med pil och textfärg
                    Console.WriteLine(options[i] + " <--");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(options[i]);  //Skriv ut resterande menyval utan pil och highlight
                }
            }

            var keyPressed = Console.ReadKey();

            if (keyPressed.Key == ConsoleKey.DownArrow && menuChoice < options.Length - 1)  //Om menyVal inte redan är på sista index , gå fram ett element
            {
                menuChoice++;
            }
            else if (keyPressed.Key == ConsoleKey.UpArrow && menuChoice > 0)    //Om menyVal inte redan är på index 0, gå tillbaka ett element
            {
                menuChoice--;
            }
            else if (keyPressed.Key == ConsoleKey.Enter)    //Välj nuvarande index
            {
                return menuChoice;
            }
            else if (keyPressed.Key == ConsoleKey.Backspace)    //Vid tryck på "Backspace", välj sista menyvalet(Avsluta/Gå Tillbaka)
            {
                return options.Length - 1;
            }
        }
        return -1;
    }

    //Meny-metoder som anropar olika metoder baserat på menyval, anropar först ShowMenu() för själva gränssnittet.
    public static void MainMenu()
    {
        bool runMenu = true;
        while (runMenu)
        {
            //Lägg till så många menyval du vill i menuChoice-Array
            int menuChoice = ShowMenu(new string[] { "1. Lägg till resmål", "2. Ta bort resmål", "3. Visa resloggen", "4. Rensa resloggen", "5. Avsluta" });
            switch (menuChoice)
            {
                case 0:
                    Resehanterare.AddDestination();
                    //Lägg till metodanrop
                    break;
                case 1:
                    RemoveAtIndex();
                    //Lägg till metodanrop
                    break;
                case 2:
                    Resehanterare.PrintList();
                    break;
                case 3:
                    Resehanterare.reseLogg.Clear();
                    break;
                case 4:
                    //Avsluta meny
                    runMenu = false;
                    break;
            }
        }
    }

    public static void RemoveAtIndex()
    {
        while (true)
        {
            string[] removeOptions = new string[Resehanterare.reseLogg.Count +1];

            for (int i = 0; i < Resehanterare.reseLogg.Count; i++)
            {
                removeOptions[i] = $"{i + 1}. {Resehanterare.reseLogg[i].ToString()}";
            }
            removeOptions[removeOptions.Length - 1] = "Gå tillbaka";

            Console.WriteLine("Vilken resa vill du ta bort?");
            int choice = Menu.ShowRemoveMenu(removeOptions);
            if (choice == removeOptions.Length -1)
            {
                break;
            }
            else
            {
                Resehanterare.reseLogg.RemoveAt(choice);
                continue;
            }
        }
    }

    //Bekräfta Avsluta
    public static void ExitMenu()
    {
        bool runMenu = true; 
        while (runMenu)
        {                
            Console.WriteLine("Är du säker på att du vill avsluta programmet?\n");
            int menuChoice = ShowMenu(new string[] { "Ja, Avsluta", "Nej, Gå tillbaka" });
            switch (menuChoice)
            {
                case 0:
                    runMenu = false;    //Bekräfta och Avsluta program 
                    break;

                case 1:
                    MainMenu();     //Avbryt och återgå till Main-Menu
                    break;
            }
        }
    }
}