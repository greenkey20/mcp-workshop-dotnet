/// <summary>
/// Static helper class to manage monkey data and provide monkey-related operations.
/// </summary>
public static class MonkeyHelper
{
    private static readonly Random _random = new();
    private static int _randomAccessCount = 0;

    /// <summary>
    /// Sample monkey data for local testing.
    /// </summary>
    private static readonly List<Monkey> _monkeys = new()
    {
        new Monkey
        {
            Name = "Baboon",
            Location = "Africa & Asia",
            Population = 100000,
            Details = "Highly social primates known for their distinctive calls and complex social structures."
        },
        new Monkey
        {
            Name = "Capuchin",
            Location = "Central & South America",
            Population = 150000,
            Details = "Intelligent monkeys famous for their tool use and problem-solving abilities."
        },
        new Monkey
        {
            Name = "Golden Snub-nosed Monkey",
            Location = "China",
            Population = 15000,
            Details = "Endangered species with distinctive golden fur and upturned noses."
        },
        new Monkey
        {
            Name = "Howler Monkey",
            Location = "Central & South America",
            Population = 200000,
            Details = "Known for their loud vocalizations that can be heard up to 3 miles away."
        },
        new Monkey
        {
            Name = "Japanese Macaque",
            Location = "Japan",
            Population = 120000,
            Details = "Also known as snow monkeys, famous for bathing in hot springs during winter."
        },
        new Monkey
        {
            Name = "Proboscis Monkey",
            Location = "Borneo",
            Population = 7000,
            Details = "Endangered species with large, distinctive noses and excellent swimming abilities."
        },
        new Monkey
        {
            Name = "Spider Monkey",
            Location = "Central & South America",
            Population = 250000,
            Details = "Agile primates with long limbs and prehensile tails, excellent at swinging through trees."
        },
        new Monkey
        {
            Name = "Vervet Monkey",
            Location = "Eastern & Southern Africa",
            Population = 500000,
            Details = "Small, adaptable monkeys known for their distinct alarm calls for different predators."
        }
    };

    /// <summary>
    /// Gets all available monkeys.
    /// </summary>
    /// <returns>A collection of all monkey data.</returns>
    public static IEnumerable<Monkey> GetAllMonkeys()
    {
        return _monkeys.AsReadOnly();
    }

    /// <summary>
    /// Finds a monkey by its name (case-insensitive search).
    /// </summary>
    /// <param name="name">The name of the monkey to find.</param>
    /// <returns>The monkey if found, otherwise null.</returns>
    public static Monkey? FindMonkeyByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return null;

        return _monkeys.FirstOrDefault(m => 
            string.Equals(m.Name, name, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Gets a random monkey from the collection and increments the access counter.
    /// </summary>
    /// <returns>A randomly selected monkey.</returns>
    public static Monkey GetRandomMonkey()
    {
        _randomAccessCount++;
        var randomIndex = _random.Next(_monkeys.Count);
        return _monkeys[randomIndex];
    }

    /// <summary>
    /// Gets the number of times a random monkey has been accessed.
    /// </summary>
    /// <returns>The access count for random monkey selections.</returns>
    public static int GetRandomAccessCount()
    {
        return _randomAccessCount;
    }
}