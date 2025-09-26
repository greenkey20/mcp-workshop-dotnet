using MyMonkeyApp;

/// <summary>
/// Main entry point for the Monkey Console Application.
/// </summary>
class Program
{
    /// <summary>
    /// Main method that runs the application menu loop.
    /// </summary>
    /// <param name="args">Command line arguments.</param>
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine(AsciiArt.GetWelcomeBanner());
        
        bool keepRunning = true;
        
        while (keepRunning)
        {
            DisplayMenu();
            var choice = GetUserChoice();
            
            switch (choice)
            {
                case 1:
                    ListAllMonkeys();
                    break;
                case 2:
                    GetMonkeyByName();
                    break;
                case 3:
                    GetRandomMonkey();
                    break;
                case 4:
                    keepRunning = false;
                    break;
                default:
                    Console.WriteLine("❌ Invalid choice. Please try again.");
                    break;
            }
            
            if (keepRunning)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        
        Console.WriteLine(AsciiArt.GetGoodbyeMessage());
    }

    /// <summary>
    /// Displays the main menu options.
    /// </summary>
    private static void DisplayMenu()
    {
        Console.WriteLine("╔════════════════════════════════════╗");
        Console.WriteLine("║              MAIN MENU             ║");
        Console.WriteLine("╠════════════════════════════════════╣");
        Console.WriteLine("║  1. 📋 List all monkeys            ║");
        Console.WriteLine("║  2. 🔍 Get details for a monkey    ║");
        Console.WriteLine("║  3. 🎲 Get a random monkey         ║");
        Console.WriteLine("║  4. 🚪 Exit application            ║");
        Console.WriteLine("╚════════════════════════════════════╝");
        Console.Write("\nEnter your choice (1-4): ");
    }

    /// <summary>
    /// Gets and validates user input for menu choice.
    /// </summary>
    /// <returns>The user's menu choice as an integer.</returns>
    private static int GetUserChoice()
    {
        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            return choice;
        }
        return -1; // Invalid choice
    }

    /// <summary>
    /// Lists all available monkeys in a formatted table.
    /// </summary>
    private static void ListAllMonkeys()
    {
        Console.Clear();
        Console.WriteLine("📋 ALL AVAILABLE MONKEYS");
        Console.WriteLine("═".PadRight(50, '═'));
        
        var monkeys = MonkeyHelper.GetAllMonkeys();
        
        Console.WriteLine($"{"No.",-4} {"Name",-25} {"Location",-20} {"Population",-12}");
        Console.WriteLine("─".PadRight(65, '─'));
        
        for (int i = 0; i < monkeys.Count; i++)
        {
            var monkey = monkeys[i];
            Console.WriteLine($"{i + 1,-4} {monkey.Name,-25} {monkey.Location,-20} {monkey.Population,-12:N0}");
        }
        
        Console.WriteLine("─".PadRight(65, '─'));
        Console.WriteLine($"Total: {MonkeyHelper.GetMonkeyCount()} monkey species");
        
        // Show random ASCII art
        Console.WriteLine(AsciiArt.GetRandomMonkeyArt());
    }

    /// <summary>
    /// Gets details for a specific monkey by name.
    /// </summary>
    private static void GetMonkeyByName()
    {
        Console.Clear();
        Console.WriteLine("🔍 FIND MONKEY BY NAME");
        Console.WriteLine("═".PadRight(30, '═'));
        
        Console.Write("Enter monkey name: ");
        var name = Console.ReadLine();
        
        var monkey = MonkeyHelper.FindMonkeyByName(name ?? string.Empty);
        
        if (monkey != null)
        {
            Console.WriteLine("\n✅ Monkey found!");
            Console.WriteLine("─".PadRight(40, '─'));
            Console.WriteLine($"Name:       {monkey.Name}");
            Console.WriteLine($"Location:   {monkey.Location}");
            Console.WriteLine($"Population: {monkey.Population:N0}");
            Console.WriteLine($"Details:    {monkey.Details}");
            Console.WriteLine("─".PadRight(40, '─'));
            
            // Show random ASCII art
            Console.WriteLine(AsciiArt.GetRandomMonkeyArt());
        }
        else
        {
            Console.WriteLine($"\n❌ No monkey found with name '{name}'");
            Console.WriteLine("\nAvailable monkey names:");
            var allMonkeys = MonkeyHelper.GetAllMonkeys();
            foreach (var m in allMonkeys)
            {
                Console.WriteLine($"  • {m.Name}");
            }
        }
    }

    /// <summary>
    /// Gets and displays a random monkey.
    /// </summary>
    private static void GetRandomMonkey()
    {
        Console.Clear();
        Console.WriteLine("🎲 RANDOM MONKEY GENERATOR");
        Console.WriteLine("═".PadRight(35, '═'));
        
        var randomMonkey = MonkeyHelper.GetRandomMonkey();
        
        Console.WriteLine("\n🎉 Here's your random monkey!");
        Console.WriteLine("─".PadRight(40, '─'));
        Console.WriteLine($"Name:       {randomMonkey.Name}");
        Console.WriteLine($"Location:   {randomMonkey.Location}");
        Console.WriteLine($"Population: {randomMonkey.Population:N0}");
        Console.WriteLine($"Details:    {randomMonkey.Details}");
        Console.WriteLine("─".PadRight(40, '─'));
        Console.WriteLine($"Random monkeys accessed: {MonkeyHelper.RandomAccessCount} times");
        
        // Show random ASCII art
        Console.WriteLine(AsciiArt.GetRandomMonkeyArt());
    }
}
