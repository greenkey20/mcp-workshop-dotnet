namespace MyMonkeyApp;

public static class MonkeyHelper
{
    private static readonly List<Monkey> _monkeys = new()
    {
        new Monkey
        {
            Name = "Baboon",
            Location = "Africa & Asia",
            Details = "Baboons are African and Arabian Old World monkeys belonging to the genus Papio, part of the subfamily Cercopithecinae.",
            Image = "🐒",
            Population = 10000,
            Latitude = -8.783195,
            Longitude = 34.508523
        },
        new Monkey
        {
            Name = "Capuchin Monkey",
            Location = "Central & South America",
            Details = "The capuchin monkeys are New World monkeys of the subfamily Cebinae. Prior to 2011, the subfamily contained only a single genus, Cebus.",
            Image = "🐵",
            Population = 23000,
            Latitude = 14.235004,
            Longitude = -51.92528
        },
        new Monkey
        {
            Name = "Blue Monkey",
            Location = "Central and East Africa",
            Details = "The blue monkey or diademed monkey is a species of Old World monkey native to Central and East Africa, ranging from the upper Congo River basin east to the East African Rift and south to northern Angola and Zambia",
            Image = "🔵🐒",
            Population = 200000,
            Latitude = -13.083333,
            Longitude = 27.849998
        },
        new Monkey
        {
            Name = "Squirrel Monkey",
            Location = "Central & South America",
            Details = "The squirrel monkeys are the New World monkeys of the genus Saimiri. They are the only genus in the subfamily Saimirinae. The name of the genus Saimiri is of Tupi origin, and was also used as an English name by early researchers.",
            Image = "🐿️🐒",
            Population = 300000,
            Latitude = -2.0333333,
            Longitude = -54.9052777
        },
        new Monkey
        {
            Name = "Golden Lion Tamarin",
            Location = "Brazil",
            Details = "The golden lion tamarin also known as the golden marmoset, is a small New World monkey of the family Callitrichidae.",
            Image = "🦁🐒",
            Population = 3000,
            Latitude = -22.9006,
            Longitude = -42.2991
        },
        new Monkey
        {
            Name = "Howler Monkey",
            Location = "South America",
            Details = "Howler monkeys are among the largest of the New World monkeys. Fifteen species are currently recognised. Previously classified in the family Cebidae, they are now placed in the family Atelidae.",
            Image = "🐒📢",
            Population = 25000,
            Latitude = -14.235004,
            Longitude = -51.92528
        },
        new Monkey
        {
            Name = "Japanese Macaque",
            Location = "Japan",
            Details = "The Japanese macaque, is a terrestrial Old World monkey species that is native to Japan. They are also sometimes known as the snow monkey because they live in areas where snow covers the ground for months each year",
            Image = "🐒❄️",
            Population = 120000,
            Latitude = 36.204824,
            Longitude = 138.252924
        }
    };

    private static readonly Random _random = new();
    private static int _randomAccessCount = 0;

    public static List<Monkey> GetAllMonkeys()
    {
        return _monkeys.ToList();
    }

    public static Monkey? GetRandomMonkey()
    {
        if (_monkeys.Count == 0) return null;
        
        _randomAccessCount++;
        var randomIndex = _random.Next(_monkeys.Count);
        return _monkeys[randomIndex];
    }

    public static Monkey? FindMonkeyByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return null;
        
        return _monkeys.FirstOrDefault(m => 
            string.Equals(m.Name, name, StringComparison.OrdinalIgnoreCase));
    }

    public static int GetRandomAccessCount()
    {
        return _randomAccessCount;
    }
}