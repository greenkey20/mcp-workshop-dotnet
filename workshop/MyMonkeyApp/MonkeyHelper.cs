namespace MyMonkeyApp;

/// <summary>
/// Static helper class that manages a collection of monkey data and provides operations to access and manipulate the data.
/// </summary>
public static class MonkeyHelper
{
    /// <summary>
    /// Gets the count of how many times a random monkey has been accessed.
    /// </summary>
    public static int RandomAccessCount { get; private set; } = 0;

    /// <summary>
    /// Private collection of all available monkeys.
    /// </summary>
    private static readonly List<Monkey> _monkeys = new()
    {
        new Monkey 
        { 
            Name = "Baboon", 
            Location = "Africa & Arabia", 
            Population = 100000,
            Details = "Large, powerful primates with dog-like faces and impressive social structures."
        },
        new Monkey 
        { 
            Name = "Capuchin", 
            Location = "Central & South America", 
            Population = 50000,
            Details = "Intelligent small monkeys known for their tool use and problem-solving abilities."
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
            Name = "Howler Monkey", 
            Location = "Central & South America", 
            Population = 75000,
            Details = "Known for their loud howling calls that can be heard up to 3 miles away."
        },
        new Monkey 
        { 
            Name = "Spider Monkey", 
            Location = "Central & South America", 
            Population = 35000,
            Details = "Agile primates with long limbs and prehensile tails, excellent at swinging through trees."
        },
        new Monkey 
        { 
            Name = "Proboscis Monkey", 
            Location = "Borneo", 
            Population = 7000,
            Details = "Distinctive large-nosed primates found only in the mangrove forests of Borneo."
        },
        new Monkey 
        { 
            Name = "Golden Snub-nosed Monkey", 
            Location = "China", 
            Population = 15000,
            Details = "Rare mountain-dwelling primates with beautiful golden fur and flat noses."
        },
        new Monkey 
        { 
            Name = "Mandrill", 
            Location = "Equatorial Africa", 
            Population = 25000,
            Details = "The world's largest monkey species, known for colorful facial markings in males."
        }
    };

    /// <summary>
    /// Gets all available monkeys.
    /// </summary>
    /// <returns>A read-only collection of all monkeys.</returns>
    public static IReadOnlyList<Monkey> GetAllMonkeys()
    {
        return _monkeys.AsReadOnly();
    }

    /// <summary>
    /// Gets a random monkey from the collection and increments the access count.
    /// </summary>
    /// <returns>A randomly selected monkey.</returns>
    public static Monkey GetRandomMonkey()
    {
        var random = new Random();
        var randomIndex = random.Next(_monkeys.Count);
        RandomAccessCount++;
        return _monkeys[randomIndex];
    }

    /// <summary>
    /// Finds a monkey by name (case-insensitive search).
    /// </summary>
    /// <param name="name">The name of the monkey to search for.</param>
    /// <returns>The monkey if found, otherwise null.</returns>
    public static Monkey? FindMonkeyByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return null;

        return _monkeys.FirstOrDefault(m => 
            m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Gets the total count of monkeys in the collection.
    /// </summary>
    /// <returns>The number of monkeys available.</returns>
    public static int GetMonkeyCount()
    {
        return _monkeys.Count;
    }
}