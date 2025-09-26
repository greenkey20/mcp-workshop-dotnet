/// <summary>
/// Static class containing ASCII art for the console application
/// </summary>
public static class AsciiArt
{
    private static readonly Random _random = new();

    /// <summary>
    /// Collection of monkey-themed ASCII art
    /// </summary>
    private static readonly string[] _monkeyArt = {
        @"
    🐵 MONKEY CONSOLE APP 🐵
        .-""-.
       /     \
      | () () |
       \  ^  /
        ||||
        ||||
",
        @"
      🙈🙉🙊
     /\_/\  /\_/\  /\_/\
    ( o.o )( o.o )( o.o )
     > ^ <  > ^ <  > ^ <
    See No  Hear No Speak No
      Evil    Evil    Evil
",
        @"
    🐒 Welcome to Monkey Business! 🐒
           .-""""""-.
          /        \
         /_        _\
        // \      / \\
        |\__\    /__/|
         \    ||    /
          \        /
           \  __  /
            '-..-'
",
        @"
     🍌 BANANA BREAK! 🍌
        \   /
         \_/
         | |
         |_|
        /   \
       /     \
      /       \
     /_________\
",
        @"
   🐵 Monkey See, Monkey Do! 🐵
         .-""-.
        (  o  )
         \ - /
         /| |\
        / | | \
           |
        .--'---.
       /       \
      |  HELLO! |
       \       /
        '-----'
"
    };

    /// <summary>
    /// Gets a random ASCII art string
    /// </summary>
    /// <returns>A random ASCII art string</returns>
    public static string GetRandomArt()
    {
        int index = _random.Next(_monkeyArt.Length);
        return _monkeyArt[index];
    }

    /// <summary>
    /// Gets the main header art for the application
    /// </summary>
    /// <returns>The main header ASCII art</returns>
    public static string GetHeaderArt()
    {
        return @"
    ╔══════════════════════════════════════╗
    ║          🐵 MONKEY CONSOLE 🐵        ║
    ║              APPLICATION              ║
    ╚══════════════════════════════════════╝
";
    }

    /// <summary>
    /// Gets a farewell ASCII art
    /// </summary>
    /// <returns>A farewell ASCII art string</returns>
    public static string GetFarewellArt()
    {
        return @"
    🐵 Thanks for visiting! 🐵
           \   o   /
            \ \_/ /
             \___/
           --'   '--
          /         \
         |  GOODBYE! |
          \         /
           '-......-'
    
    See you later, alligator!
    (Or should we say... monkey?)
";
    }
}