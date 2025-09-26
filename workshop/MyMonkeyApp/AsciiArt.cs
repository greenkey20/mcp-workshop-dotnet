namespace MyMonkeyApp;

/// <summary>
/// Provides ASCII art for visual appeal in the console application.
/// </summary>
public static class AsciiArt
{
    /// <summary>
    /// Collection of monkey-themed ASCII art.
    /// </summary>
    private static readonly string[] _monkeyArt = new[]
    {
        @"
      __
   w  c(..)o   (
    \__(-)    __)
        /\   (
       /(_)___)
      w /|
       | \
      m  m
",
        @"
    .-""-.
   /     \
  | () () |
   \  ^  /
    |||||
    |||||
",
        @"
     .=""=.
   _/.-.-.\_
  ( ( o o ) )
   |/  ""  \|
    \_^^^_/
   beeep!
",
        @"
   @@@@@@@@@@@
  @             @
 @  () ()    ()  @
@     <>         @
@        ___     @
 @      \___/    @
  @             @
   @@@@@@@@@@@
"
    };

    /// <summary>
    /// Gets a random piece of monkey ASCII art.
    /// </summary>
    /// <returns>A string containing ASCII art.</returns>
    public static string GetRandomMonkeyArt()
    {
        var random = new Random();
        var index = random.Next(_monkeyArt.Length);
        return _monkeyArt[index];
    }

    /// <summary>
    /// Gets the welcome banner for the application.
    /// </summary>
    /// <returns>A welcome banner with ASCII art.</returns>
    public static string GetWelcomeBanner()
    {
        return @"
╔══════════════════════════════════════╗
║        🐵 MONKEY CONSOLE APP 🐵       ║
║     Discover Amazing Monkey Facts    ║
╚══════════════════════════════════════╝
";
    }

    /// <summary>
    /// Gets a goodbye message with ASCII art.
    /// </summary>
    /// <returns>A goodbye message.</returns>
    public static string GetGoodbyeMessage()
    {
        return @"
╔════════════════════════════════════╗
║     Thanks for using Monkey App!   ║
║        🐵 See you next time! 🐵     ║
╚════════════════════════════════════╝
";
    }
}