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