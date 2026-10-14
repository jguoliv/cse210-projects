class Journal
{
    // attributes
    public List<Entry> _entries = new List<Entry>();

    // behaviors
    public void AddEntry(string date, string mood, string prompt, string response)
    {
        Entry newEntry = new Entry();
        newEntry._date = date;
        newEntry._mood = mood;
        newEntry._prompt = prompt;
        newEntry._response = response;
        _entries.Add(newEntry);
    }

    public void DisplayEntries()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveJournal(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}~|~{entry._mood}~|~{entry._prompt}~|~{entry._response}");
            }
        }
    }

    public void LoadJournal(string filename)
    {
        _entries.Clear();
        string[] lines = System.IO.File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split("~|~");

            Entry entry = new Entry();
            entry._date = parts[0];
            entry._mood = parts[1];
            entry._prompt = parts[2];
            entry._response = parts[3];

            _entries.Add(entry);
        }
    }
}

class Entry
{
    // attributes
    public string _date = "";
    public string _mood = "";
    public string _prompt = "";
    public string _response = "";

    // behaviors
    public void Display()
    {
        Console.WriteLine("");
        Console.WriteLine($"Date: {_date} - Mood: {_mood}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"{_response}");
    }
}

class PromptGenerator
{
    // attribute
    public List<string> _prompts =
    [
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is something I learned today?",
        "What is one thing I'm grateful for right now?",
        "What is something I did today that I'm proud of?",
        "What is one small thing that made me smile today?",
        "What is one thing I want to do better tomorrow?"
    ];

    // behavior
    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}