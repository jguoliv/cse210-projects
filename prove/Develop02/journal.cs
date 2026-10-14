class Journal
{
    // attributes
    public List<Entry> _entries = [];

    // behaviors
    public void AddEntry(string date, string prompt, string response)
    {
        Entry newEntry = new Entry();
        newEntry._date = date;
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
                outputFile.WriteLine($"{entry._date}~{entry._prompt}~{entry._response}");
            }
        }
    }

    public void LoadJournal(string filename)
    {
        _entries.Clear();
        string[] lines = System.IO.File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string [] parts = line.
        }
    }

    public void RemoveEntry()
    {
        
    }
}

class Entry
{
    // attributes
    public string _date = "";
    public string _prompt = "";
    public string _response = "";

    // behaviors
    public void Display()
    {
        Console.WriteLine("");
        Console.WriteLine($"Date: {_date} - Prompt: {_prompt}");
        Console.WriteLine($"{_response}");
    }

    public void Edit()
    {
        
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