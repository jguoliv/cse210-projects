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