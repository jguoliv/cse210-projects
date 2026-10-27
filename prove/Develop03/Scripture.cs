public class Scripture
{
    // attributes
    private readonly List<Word> _words;
    private readonly Reference _reference;
    private readonly Random _random;

    // constructor
    public Scripture(string rawText, Reference reference)
    {
        _reference = reference;
        _random = new Random();
        _words = new List<Word>();
        string[] words = rawText.Split(' ');

        foreach (string word in words)
        {
            if (word != "")
            {
                _words.Add(new Word(word));
            }
        }
    }

    // behaviors
    public void Display()
    {
        Console.WriteLine(_reference.Get());
        Console.WriteLine();

        foreach (Word word in _words)
        {
            Console.Write($"{word.GetDisplayString()} ");
        }

        Console.WriteLine();
    }

    public void HideRandomWord()
    {
        List<Word> visibleWords = new List<Word>();

        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                visibleWords.Add(word);
            }
        }

        if (visibleWords.Count > 0)
        {
            int index = _random.Next(visibleWords.Count);
            visibleWords[index].Hide();
        }
    }

    public void ShowRandomWord()
    {
        List<Word> hiddenWords = new List<Word>();

        foreach (Word word in _words)
        {
            if (word.IsHidden())
            {
                hiddenWords.Add(word);
            }
        }

        if (hiddenWords.Count > 0)
        {
            int index = _random.Next(hiddenWords.Count);
            hiddenWords[index].Show();
        }
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }

        return true;
    }
}
