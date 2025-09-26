using MyMonkeyApp;

Console.Clear();
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("🐒 Welcome to the Monkey App! 🐒");
Console.ResetColor();

// Display random ASCII art on startup
AsciiArt.DisplayRandomArt();

bool exitRequested = false;

while (!exitRequested)
{
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("=== MONKEY MENU ===");
    Console.ResetColor();
    Console.WriteLine("1. List all monkeys");
    Console.WriteLine("2. Get details for a specific monkey by name");
    Console.WriteLine("3. Get a random monkey");
    Console.WriteLine("4. Exit app");
    Console.WriteLine();
    
    Console.Write("Please select an option (1-4): ");
    var input = Console.ReadLine();

    switch (input?.Trim())
    {
        case "1":
            ListAllMonkeys();
            break;
        case "2":
            GetSpecificMonkey();
            break;
        case "3":
            GetRandomMonkey();
            break;
        case "4":
            exitRequested = true;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Thanks for using the Monkey App! 🐒👋");
            Console.ResetColor();
            break;
        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid option. Please select 1-4.");
            Console.ResetColor();
            break;
    }

    if (!exitRequested)
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
        Console.Clear();
        
        // Show random ASCII art between operations
        if (Random.Shared.Next(3) == 0) // 33% chance
        {
            AsciiArt.DisplayRandomArt();
        }
    }
}

static void ListAllMonkeys()
{
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("=== ALL MONKEYS ===");
    Console.ResetColor();
    
    var monkeys = MonkeyHelper.GetAllMonkeys();
    
    if (monkeys.Count == 0)
    {
        Console.WriteLine("No monkeys found!");
        return;
    }

    Console.WriteLine($"{"Name",-20} {"Location",-25} {"Population",-12} {"Image",5}");
    Console.WriteLine(new string('-', 65));
    
    foreach (var monkey in monkeys)
    {
        Console.WriteLine($"{monkey.Name,-20} {monkey.Location,-25} {monkey.Population,-12:N0} {monkey.Image,5}");
    }
    
    Console.WriteLine($"\nTotal monkeys: {monkeys.Count}");
}

static void GetSpecificMonkey()
{
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("=== FIND SPECIFIC MONKEY ===");
    Console.ResetColor();
    
    Console.Write("Enter the name of the monkey: ");
    var name = Console.ReadLine();
    
    if (string.IsNullOrWhiteSpace(name))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Please enter a valid monkey name.");
        Console.ResetColor();
        return;
    }
    
    var monkey = MonkeyHelper.FindMonkeyByName(name);
    
    if (monkey == null)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Monkey '{name}' not found!");
        Console.ResetColor();
        
        // Show available monkeys
        Console.WriteLine("\nAvailable monkeys:");
        var allMonkeys = MonkeyHelper.GetAllMonkeys();
        foreach (var m in allMonkeys)
        {
            Console.WriteLine($"- {m.Name}");
        }
    }
    else
    {
        DisplayMonkeyDetails(monkey);
    }
}

static void GetRandomMonkey()
{
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("=== RANDOM MONKEY ===");
    Console.ResetColor();
    
    var monkey = MonkeyHelper.GetRandomMonkey();
    
    if (monkey == null)
    {
        Console.WriteLine("No monkeys available!");
        return;
    }
    
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("🎲 Rolling the dice... 🎲");
    Console.ResetColor();
    
    // Add some suspense
    Thread.Sleep(1000);
    
    DisplayMonkeyDetails(monkey);
    
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"Random monkeys selected so far: {MonkeyHelper.GetRandomAccessCount()}");
    Console.ResetColor();
}

static void DisplayMonkeyDetails(Monkey monkey)
{
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"🐒 {monkey.Name} {monkey.Image}");
    Console.WriteLine(new string('=', monkey.Name.Length + 4));
    Console.ResetColor();
    
    Console.WriteLine($"Location: {monkey.Location}");
    Console.WriteLine($"Population: {monkey.Population:N0}");
    Console.WriteLine($"Coordinates: ({monkey.Latitude:F2}, {monkey.Longitude:F2})");
    Console.WriteLine();
    Console.WriteLine("Details:");
    Console.WriteLine(monkey.Details);
}
