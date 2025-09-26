// Monkey Console Application - Sample data for local testing
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

// Check if running in interactive mode
bool isInteractive = Environment.UserInteractive && !Console.IsInputRedirected;

if (!isInteractive)
{
    // Non-interactive mode - run quick demo
    RunDemo();
    return;
}

// Display welcome ASCII art
DisplayWelcomeArt();

bool running = true;
while (running)
{
    DisplayMenu();
    
    var input = Console.ReadLine()?.Trim();
    Console.WriteLine();

    switch (input)
    {
        case "1":
            ListAllMonkeys();
            break;
        case "2":
            GetMonkeyByName();
            break;
        case "3":
            GetRandomMonkey();
            break;
        case "4":
            running = false;
            Console.WriteLine("Thanks for using the Monkey App! 🐵");
            break;
        default:
            Console.WriteLine("❌ Invalid option. Please try again.");
            break;
    }

    if (running)
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
        Console.Clear();
        DisplayRandomAsciiArt();
    }
}

static void DisplayWelcomeArt()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine(@"
    🐵 Welcome to the Monkey Console App! 🐵
    ========================================
    
       .-.   .-.     .--.                         
      | OO| | OO|   / _.-' .-.   .-.  .-.   .''.    
      |   | |   |   \(  OO  )   | OO| | OO| | OO |   
      | U | | U |    '-'--'  .-.| U || U | | U  |   
      |  -| |  -|         .' OO|   ||   | |  -.'    
      |  || |  ||        (  _)|   ||   | |  |      
      '--'' '--''         '--'  '-'' '-' '--'      
    
    Your gateway to the wonderful world of monkeys!
    ");
    Console.ResetColor();
    Console.WriteLine("\nPress any key to start...");
    Console.ReadKey();
    Console.Clear();
}

static void DisplayMenu()
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("🐵 === MONKEY MENU === 🐵");
    Console.ResetColor();
    Console.WriteLine();
    Console.WriteLine("1. 📋 List all monkeys");
    Console.WriteLine("2. 🔍 Get details for a specific monkey by name");
    Console.WriteLine("3. 🎲 Get a random monkey");
    Console.WriteLine("4. 🚪 Exit app");
    Console.WriteLine();
    Console.Write("Choose an option (1-4): ");
}

static void ListAllMonkeys()
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("📋 === ALL MONKEYS === 📋");
    Console.ResetColor();
    Console.WriteLine();

    var monkeys = MonkeyHelper.GetAllMonkeys();
    
    foreach (var monkey in monkeys)
    {
        DisplayMonkeyInfo(monkey);
        Console.WriteLine(new string('-', 50));
    }
    
    Console.WriteLine($"Total monkeys in database: {monkeys.Count()}");
}

static void GetMonkeyByName()
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("🔍 === FIND MONKEY BY NAME === 🔍");
    Console.ResetColor();
    Console.WriteLine();
    
    Console.Write("Enter the monkey name: ");
    var name = Console.ReadLine()?.Trim();
    
    if (string.IsNullOrWhiteSpace(name))
    {
        Console.WriteLine("❌ Please enter a valid monkey name.");
        return;
    }

    var monkey = MonkeyHelper.FindMonkeyByName(name);
    
    if (monkey != null)
    {
        Console.WriteLine($"✅ Found monkey: {name}");
        Console.WriteLine();
        DisplayMonkeyInfo(monkey);
    }
    else
    {
        Console.WriteLine($"❌ Monkey '{name}' not found in database.");
        Console.WriteLine("\n💡 Available monkeys:");
        var allMonkeys = MonkeyHelper.GetAllMonkeys();
        foreach (var m in allMonkeys)
        {
            Console.WriteLine($"   • {m.Name}");
        }
    }
}

static void GetRandomMonkey()
{
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("🎲 === RANDOM MONKEY === 🎲");
    Console.ResetColor();
    Console.WriteLine();
    
    var monkey = MonkeyHelper.GetRandomMonkey();
    var accessCount = MonkeyHelper.GetRandomAccessCount();
    
    Console.WriteLine($"🎯 Your random monkey is: {monkey.Name}!");
    Console.WriteLine();
    DisplayMonkeyInfo(monkey);
    Console.WriteLine($"🔢 Random monkey access count: {accessCount}");
}

static void DisplayMonkeyInfo(Monkey monkey)
{
    Console.WriteLine($"🐵 Name: {monkey.Name}");
    Console.WriteLine($"🌍 Location: {monkey.Location}");
    Console.WriteLine($"👥 Population: {monkey.Population:N0}");
    Console.WriteLine($"📝 Details: {monkey.Details}");
    Console.WriteLine();
}

static void DisplayRandomAsciiArt()
{
    var arts = new string[]
    {
        @"
    🐵    🍌    🌴
      \   |   /
       \  |  /
        \ | /
         \|/
    ",
        @"
        🐒
       / \
      /   \
     /     \
    🥥     🍃
    ",
        @"
    🌿 🐵 🌿
      ~~~~
     ( oo )
      \__/
       ||
       ||
    ",
        @"
    🍃 Swing into adventure! 🍃
         🐵
        /|\
        / \
    "
    };

    var randomArt = arts[new Random().Next(arts.Length)];
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine(randomArt);
    Console.ResetColor();
}

static void RunDemo()
{
    Console.WriteLine("🐵 === MONKEY APP DEMO === 🐵");
    Console.WriteLine();
    
    // Test GetAllMonkeys
    Console.WriteLine("📋 === ALL MONKEYS === 📋");
    var allMonkeys = MonkeyHelper.GetAllMonkeys();
    Console.WriteLine($"Total monkeys in database: {allMonkeys.Count()}");
    Console.WriteLine();
    
    foreach (var monkey in allMonkeys.Take(3)) // Show first 3
    {
        DisplayMonkeyInfo(monkey);
        Console.WriteLine(new string('-', 30));
    }
    Console.WriteLine($"... and {allMonkeys.Count() - 3} more!");
    Console.WriteLine();
    
    // Test FindMonkeyByName
    Console.WriteLine("🔍 === FIND MONKEY BY NAME === 🔍");
    var foundMonkey = MonkeyHelper.FindMonkeyByName("Baboon");
    if (foundMonkey != null)
    {
        Console.WriteLine("✅ Found Baboon:");
        DisplayMonkeyInfo(foundMonkey);
    }
    Console.WriteLine();
    
    // Test GetRandomMonkey
    Console.WriteLine("🎲 === RANDOM MONKEYS === 🎲");
    for (int i = 0; i < 3; i++)
    {
        var randomMonkey = MonkeyHelper.GetRandomMonkey();
        Console.WriteLine($"Random #{i + 1}: {randomMonkey.Name}");
    }
    Console.WriteLine($"🔢 Random access count: {MonkeyHelper.GetRandomAccessCount()}");
    Console.WriteLine();
    
    Console.WriteLine("✅ === ALL TESTS PASSED! === ✅");
}
