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