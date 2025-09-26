using System;
using System.Collections.Generic;
using System.Linq;
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
        // TODO: Replace with actual MCP server call
        await Task.Delay(100); // Simulate async call
        return new List<Monkey>();
    }
}
