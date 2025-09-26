// Monkey Console Application
// This application allows users to explore different monkey species

using System;

Console.Clear();
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine(AsciiArt.GetHeaderArt());
Console.ResetColor();

bool keepRunning = true;

while (keepRunning)
{
    DisplayMenu();
    
    string? choice = Console.ReadLine();
    Console.WriteLine();

    switch (choice?.ToLower())
    {
        case "1":
            ListAllMonkeys();
            break;
        case "2":
            GetMonkeyDetails();
            break;
        case "3":
            GetRandomMonkey();
            break;
        case "4":
            ShowRandomArt();
            keepRunning = false;
            break;
        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("❌ Invalid choice! Please select 1-4.");
            Console.ResetColor();
            break;
    }

    if (keepRunning)
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }
}

/// <summary>
/// Displays the main menu options
/// </summary>
static void DisplayMenu()
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("🐵 What would you like to do?");
    Console.ResetColor();
    Console.WriteLine();
    Console.WriteLine("1. 📋 List all monkeys");
    Console.WriteLine("2. 🔍 Get details for a specific monkey");
    Console.WriteLine("3. 🎲 Get a random monkey");
    Console.WriteLine("4. 🚪 Exit application");
    Console.WriteLine();
    Console.Write("Enter your choice (1-4): ");
}

/// <summary>
/// Lists all available monkeys in a formatted table
/// </summary>
static void ListAllMonkeys()
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("🐵 All Available Monkeys:");
    Console.WriteLine(new string('=', 80));
    Console.ResetColor();

    var monkeys = MonkeyHelper.GetAllMonkeys();
    
    Console.WriteLine($"{"Name",-25} {"Location",-30} {"Population",-15}");
    Console.WriteLine(new string('-', 80));

    foreach (var monkey in monkeys)
    {
        Console.WriteLine($"{monkey.Name,-25} {monkey.Location,-30} {monkey.Population,-15:N0}");
    }

    Console.WriteLine(new string('=', 80));
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"📊 Total species: {monkeys.Count}");
    Console.ResetColor();
}

/// <summary>
/// Gets and displays details for a specific monkey by name
/// </summary>
static void GetMonkeyDetails()
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("🔍 Get Monkey Details");
    Console.WriteLine(new string('=', 50));
    Console.ResetColor();

    Console.WriteLine("Available monkeys:");
    var monkeyNames = MonkeyHelper.GetMonkeyNames();
    for (int i = 0; i < monkeyNames.Count; i++)
    {
        Console.WriteLine($"  • {monkeyNames[i]}");
    }

    Console.WriteLine();
    Console.Write("Enter monkey name: ");
    string? input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("❌ Please enter a monkey name.");
        Console.ResetColor();
        return;
    }

    var monkey = MonkeyHelper.FindMonkeyByName(input);

    if (monkey == null)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"❌ No monkey found with name '{input}'.");
        Console.WriteLine("💡 Tip: Try typing the full name as shown in the list above.");
        Console.ResetColor();
        return;
    }

    DisplayMonkeyDetails(monkey);
}

/// <summary>
/// Gets and displays a random monkey
/// </summary>
static void GetRandomMonkey()
{
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("🎲 Random Monkey Generator");
    Console.WriteLine(new string('=', 50));
    Console.ResetColor();

    var randomMonkey = MonkeyHelper.GetRandomMonkey();
    var accessCount = MonkeyHelper.GetRandomAccessCount();

    Console.WriteLine("🎊 Surprise! Here's your random monkey:");
    Console.WriteLine();
    
    DisplayMonkeyDetails(randomMonkey);
    
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine($"📊 Random monkeys picked so far: {accessCount}");
    Console.ResetColor();
}

/// <summary>
/// Displays detailed information about a specific monkey
/// </summary>
/// <param name="monkey">The monkey to display details for</param>
static void DisplayMonkeyDetails(Monkey monkey)
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"🐵 {monkey.Name}");
    Console.WriteLine(new string('-', monkey.Name.Length + 3));
    Console.ResetColor();
    
    Console.WriteLine($"📍 Location: {monkey.Location}");
    Console.WriteLine($"👥 Population: {monkey.Population:N0}");
    Console.WriteLine($"ℹ️  Details: {monkey.Details}");
}

/// <summary>
/// Shows random ASCII art and goodbye message
/// </summary>
static void ShowRandomArt()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine(AsciiArt.GetFarewellArt());
    Console.ResetColor();
    
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("🎨 Here's some random art for you:");
    Console.WriteLine(AsciiArt.GetRandomArt());
    Console.ResetColor();
}
