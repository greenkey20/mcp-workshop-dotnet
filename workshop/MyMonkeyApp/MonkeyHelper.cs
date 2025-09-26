/// <summary>
/// Static helper class for managing monkey data and operations
/// </summary>
public static class MonkeyHelper
{
    private static int _randomAccessCount = 0;
    private static readonly Random _random = new();

    /// <summary>
    /// Collection of available monkeys
    /// </summary>
    private static readonly List<Monkey> _monkeys = new()
    {
        new Monkey
        {
            Name = "Proboscis Monkey",
            Location = "Borneo",
            Population = 7000,
            Details = "Known for their distinctive large noses, these monkeys are excellent swimmers and live primarily in mangrove forests."
        },
        new Monkey
        {
            Name = "Golden Lion Tamarin",
            Location = "Brazil Atlantic Forest",
            Population = 3200,
            Details = "Endangered species with beautiful golden manes, they live in family groups and are highly social."
        },
        new Monkey
        {
            Name = "Japanese Macaque",
            Location = "Japan",
            Population = 114000,
            Details = "Also known as snow monkeys, they're famous for bathing in hot springs during winter."
        },
        new Monkey
        {
            Name = "Mandrill",
            Location = "Equatorial Africa",
            Population = 25000,
            Details = "The world's largest monkey species, males have colorful faces that become more vibrant when excited."
        },
        new Monkey
        {
            Name = "Spider Monkey",
            Location = "Central and South America",
            Population = 250000,
            Details = "Highly agile primates with long limbs and prehensile tails that act like a fifth hand."
        },
        new Monkey
        {
            Name = "Howler Monkey",
            Location = "Central and South America",
            Population = 100000,
            Details = "Known for their loud calls that can be heard up to 3 miles away, they're among the loudest land animals."
        },
        new Monkey
        {
            Name = "Capuchin Monkey",
            Location = "Central and South America",
            Population = 180000,
            Details = "Highly intelligent monkeys known for using tools and their expressive faces."
        },
        new Monkey
        {
            Name = "Vervet Monkey",
            Location = "East Africa",
            Population = 500000,
            Details = "Medium-sized monkeys known for their distinct alarm calls and complex social structures."
        }
    };

    /// <summary>
    /// Gets all available monkeys
    /// </summary>
    /// <returns>A read-only collection of all monkeys</returns>
    public static IReadOnlyList<Monkey> GetAllMonkeys()
    {
        return _monkeys.AsReadOnly();
    }

    /// <summary>
    /// Gets a random monkey from the collection
    /// </summary>
    /// <returns>A randomly selected monkey</returns>
    public static Monkey GetRandomMonkey()
    {
        _randomAccessCount++;
        int index = _random.Next(_monkeys.Count);
        return _monkeys[index];
    }

    /// <summary>
    /// Finds a monkey by name (case-insensitive)
    /// </summary>
    /// <param name="name">The name of the monkey to find</param>
    /// <returns>The monkey if found, null otherwise</returns>
    public static Monkey? FindMonkeyByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return null;

        return _monkeys.FirstOrDefault(m => 
            string.Equals(m.Name, name, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Gets the number of times a random monkey has been picked
    /// </summary>
    /// <returns>The access count for random monkey selections</returns>
    public static int GetRandomAccessCount()
    {
        return _randomAccessCount;
    }

    /// <summary>
    /// Gets a list of monkey names for easy reference
    /// </summary>
    /// <returns>A list of all monkey names</returns>
    public static List<string> GetMonkeyNames()
    {
        return _monkeys.Select(m => m.Name).ToList();
    }
}