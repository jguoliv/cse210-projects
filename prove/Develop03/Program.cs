public class Program
{
    /*
     * Creativity and exceeding requirements:
     * 1. The program contains a library of scriptures and randomly chooses one at
     *    the beginning, so the user can practice more than one passage.
     * 2. The user can type "hint" to reveal one previously hidden word. This gives
     *    the user a way to recover when a word is forgotten instead of restarting.
     * 3. The program hides only words that are still visible, which makes each
     *    round meaningful and guarantees that the scripture eventually finishes.
     */

    public static void Main(string[] args)
    {
        Scripture scripture = ChooseRandomScripture();
        const int wordsToHidePerRound = 3;

        while (true)
        {
            ClearConsole();
            scripture.Display();

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine();
                Console.WriteLine("All words are hidden. Great work!");
                break;
            }

            Console.WriteLine();
            Console.Write("Press Enter to hide words, type hint to reveal one, or type quit: ");
            string response = (Console.ReadLine() ?? "quit").Trim().ToLowerInvariant();

            if (response == "quit")
            {
                break;
            }

            if (response == "hint")
            {
                scripture.ShowRandomWord();
                continue;
            }

            if (response.Length == 0)
            {
                for (int i = 0; i < wordsToHidePerRound; i++)
                {
                    scripture.HideRandomWord();
                }
            }
        }

        Console.WriteLine("Thanks for practicing!");
    }

    private static Scripture ChooseRandomScripture()
    {
        Random random = new Random();
        List<Scripture> scriptures = new List<Scripture>()
        {
            new Scripture(
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.",
                new Reference("Proverbs", 3, 5, 6)),
            new Scripture(
                "I can do all things through Christ which strengtheneth me.",
                new Reference("Philippians", 4, 13)),
            new Scripture(
                "Be still, and know that I am God.",
                new Reference("Psalms", 46, 10))
        };

        int index = random.Next(scriptures.Count);
        return scriptures[index];
    }

    private static void ClearConsole()
    {
        try
        {
            Console.Clear();
        }
        catch (IOException)
        {
            // Console.Clear can fail in some redirected or limited terminals.
        }
    }
}
