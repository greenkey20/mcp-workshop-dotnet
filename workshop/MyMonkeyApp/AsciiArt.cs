namespace MyMonkeyApp;

public static class AsciiArt
{
    private static readonly string[] _artCollection = new[]
    {
        @"
    🐒 MONKEY MADNESS! 🐒
   ╔═══════════════════╗
   ║   oo   oo   oo    ║
   ║  (__)_(__) _(__)   ║
   ║    \  |  | /      ║
   ║     \ |__| /      ║
   ║      \____/       ║
   ╚═══════════════════╝",

        @"
      🍌 BANANA TIME! 🍌
        .-""""""-.
       /  o    o  \
      |     __     |
      |    \  /    |
       \    \/    /
        `-.____.-'
         🐵🐵🐵",

        @"
   🌴 JUNGLE VIBES 🌴
      oooo$$$$$$$$$$$$oooo
   oo$$$$$$$$$$$$$$$$$$$$$$$$o
 o$$'                    `$$$o
o$'                        `$o
$'          🐒              `$
$                            $
$           MONKEYS          $
$           RULE!            $
$                            $
 $o                        o$
  $$$o                  o$$$
   `$$$$$oooooooooooo$$$$$'
      `""""""""""""""""""""'",

        @"
  🎪 MONKEY CIRCUS 🎪
     _____
    /     \
   | () () |
    \  ^  /
     |||||
     |||||
    🐒🎩🐒",

        @"
    🚀 SPACE MONKEY 🚀
        .-.
       (   )
        '-'
    🐒👩‍🚀🐒
      TO THE
     MOON!!! 🌙"
    };

    private static readonly Random _random = new();

    public static string GetRandomArt()
    {
        var index = _random.Next(_artCollection.Length);
        return _artCollection[index];
    }

    public static void DisplayRandomArt()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(GetRandomArt());
        Console.ResetColor();
    }
}