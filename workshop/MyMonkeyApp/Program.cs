
using MyMonkeyApp;

class Program
{
	private static readonly List<string> AsciiArtList = new()
	{
		"  (\\__/)",
		"  (='.'=)",
		"  (\"_)_(\")",
		"   //\\\n  ( oo )\n  (  - )\n   \\__/",
		"   .-\"\"\"-.\n  / .===. \\\n  \\/ 6 6 \\/\n  ( \\___/ )\n___ooo__ooo___"
	};

	static async Task Main()
	{
		var random = new Random();
		while (true)
		{
			Console.Clear();
			Console.WriteLine(AsciiArtList[random.Next(AsciiArtList.Count)]);
			Console.WriteLine("\nMonkey Console Application");
			Console.WriteLine("1. List all monkeys");
			Console.WriteLine("2. Get details for a specific monkey by name");
			Console.WriteLine("3. Get a random monkey");
			Console.WriteLine("4. Exit app");
			Console.Write("Select an option: ");
			var input = Console.ReadLine();

			switch (input)
			{
				case "1":
					await ListAllMonkeys();
					break;
				case "2":
					await GetMonkeyDetails();
					break;
				case "3":
					await GetRandomMonkey();
					break;
				case "4":
					Console.WriteLine("Goodbye!");
					return;
				default:
					Console.WriteLine("Invalid option. Try again.");
					break;
			}
			Console.WriteLine("\nPress any key to continue...");
			Console.ReadKey();
		}
	}

	private static async Task ListAllMonkeys()
	{
		var monkeys = await MonkeyHelper.GetMonkeysAsync();
		Console.WriteLine("\nAvailable Monkeys:");
		Console.WriteLine("-------------------------------------------------------------");
	Console.WriteLine($"{"Name",-20} {"Location",-25} {"Population",-10}");
		Console.WriteLine("-------------------------------------------------------------");
		foreach (var monkey in monkeys)
		{
			Console.WriteLine($"{monkey.Name,-20} {monkey.Location,-25} {monkey.Population,-10}");
		}
	}

	private static async Task GetMonkeyDetails()
	{
		Console.Write("Enter monkey name: ");
		var name = Console.ReadLine();
		var monkey = await MonkeyHelper.GetMonkeyByNameAsync(name ?? "");
		if (monkey == null)
		{
			Console.WriteLine("Monkey not found.");
			return;
		}
		Console.WriteLine($"\nName: {monkey.Name}\nLocation: {monkey.Location}\nPopulation: {monkey.Population}\nDetails: {monkey.Details}\nImage: {monkey.Image}\nCoordinates: ({monkey.Latitude}, {monkey.Longitude})");
	}

	private static async Task GetRandomMonkey()
	{
		var monkey = await MonkeyHelper.GetRandomMonkeyAsync();
		if (monkey == null)
		{
			Console.WriteLine("No monkeys available.");
			return;
		}
		Console.WriteLine($"\nRandom Monkey: {monkey.Name}\nLocation: {monkey.Location}\nPopulation: {monkey.Population}\nDetails: {monkey.Details}\nImage: {monkey.Image}\nCoordinates: ({monkey.Latitude}, {monkey.Longitude})");
		Console.WriteLine($"Random monkey picked {MonkeyHelper.GetRandomMonkeyAccessCount()} times.");
	}
}
