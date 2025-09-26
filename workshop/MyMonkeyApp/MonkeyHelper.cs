using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyMonkeyApp;

/// <summary>
/// Provides helper methods for managing monkey data.
/// </summary>
public static class MonkeyHelper
{
    private static List<Monkey>? monkeys;
    private static int randomMonkeyAccessCount = 0;

    /// <summary>
    /// Gets all monkeys from the MCP server.
    /// </summary>
    public static async Task<List<Monkey>> GetMonkeysAsync()
    {
        if (monkeys == null)
        {
            monkeys = await FetchMonkeysFromServerAsync();
        }
        return monkeys;
    }

    /// <summary>
    /// Gets a random monkey from the collection and tracks access count.
    /// </summary>
    public static async Task<Monkey?> GetRandomMonkeyAsync()
    {
        var allMonkeys = await GetMonkeysAsync();
        if (allMonkeys.Count == 0) return null;
        randomMonkeyAccessCount++;
        var random = new Random();
        return allMonkeys[random.Next(allMonkeys.Count)];
    }

    /// <summary>
    /// Finds a monkey by name.
    /// </summary>
    public static async Task<Monkey?> GetMonkeyByNameAsync(string name)
    {
        var allMonkeys = await GetMonkeysAsync();
        return allMonkeys.FirstOrDefault(m => string.Equals(m.Name, name, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Gets the number of times a random monkey has been picked.
    /// </summary>
    public static int GetRandomMonkeyAccessCount() => randomMonkeyAccessCount;

    /// <summary>
    /// Fetches monkey data from the MCP server.
    /// </summary>
    private static async Task<List<Monkey>> FetchMonkeysFromServerAsync()
    {
        // MCP 서버 대신 샘플 데이터 반환
        await Task.Delay(100); // 비동기 시뮬레이션
        return new List<Monkey>
        {
            new Monkey { Name = "Baboon", Location = "Africa & Asia", Population = 10000, Details = "Baboons are African and Arabian Old World monkeys belonging to the genus Papio.", Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/baboon.jpg", Latitude = -8.783195, Longitude = 34.508523 },
            new Monkey { Name = "Capuchin Monkey", Location = "Central & South America", Population = 23000, Details = "Capuchin monkeys are New World monkeys of the subfamily Cebinae.", Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/capuchin.jpg", Latitude = 12.769013, Longitude = -85.602364 },
            new Monkey { Name = "Blue Monkey", Location = "Central and East Africa", Population = 12000, Details = "The blue monkey is native to Central and East Africa.", Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/bluemonkey.jpg", Latitude = 1.957709, Longitude = 37.297204 },
            new Monkey { Name = "Squirrel Monkey", Location = "Central & South America", Population = 11000, Details = "Squirrel monkeys are the New World monkeys of the genus Saimiri.", Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/saimiri.jpg", Latitude = -8.783195, Longitude = -55.491477 },
            new Monkey { Name = "Golden Lion Tamarin", Location = "Brazil", Population = 19000, Details = "The golden lion tamarin is a small New World monkey of the family Callitrichidae.", Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/tamarin.jpg", Latitude = -14.235004, Longitude = -51.92528 },
            new Monkey { Name = "Howler Monkey", Location = "South America", Population = 8000, Details = "Howler monkeys are among the largest of the New World monkeys.", Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/alouatta.jpg", Latitude = -8.783195, Longitude = -55.491477 },
            new Monkey { Name = "Japanese Macaque", Location = "Japan", Population = 1000, Details = "The Japanese macaque is native to Japan, also known as the snow monkey.", Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/macasa.jpg", Latitude = 36.204824, Longitude = 138.252924 },
            new Monkey { Name = "Mandrill", Location = "Southern Cameroon, Gabon, Congo", Population = 17000, Details = "The mandrill is a primate closely related to baboons and drills.", Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/mandrill.jpg", Latitude = 7.369722, Longitude = 12.354722 },
            new Monkey { Name = "Proboscis Monkey", Location = "Borneo", Population = 15000, Details = "The proboscis monkey is endemic to Borneo.", Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/borneo.jpg", Latitude = 0.961883, Longitude = 114.55485 },
            new Monkey { Name = "Sebastian", Location = "Seattle", Population = 1, Details = "Lives in Seattle, loves traveling and tweeting @MotzMonkeys.", Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/sebastian.jpg", Latitude = 47.606209, Longitude = -122.332071 },
            new Monkey { Name = "Henry", Location = "Phoenix", Population = 1, Details = "Traveling the world, live tweets adventures @MotzMonkeys.", Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/henry.jpg", Latitude = 33.448377, Longitude = -112.074037 },
            new Monkey { Name = "Red-shanked douc", Location = "Vietnam", Population = 1300, Details = "The red-shanked douc is among the most colourful of all primates.", Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/douc.jpg", Latitude = 16.111648, Longitude = 108.262122 },
            new Monkey { Name = "Mooch", Location = "Seattle", Population = 1, Details = "Traveling the world, live tweets adventures @MotzMonkeys.", Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/Mooch.PNG", Latitude = 47.608013, Longitude = -122.335167 }
        };
    }
}
