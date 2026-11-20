using System;

public abstract class Goal
{
    private string _title;
    private string _description;
    private int _points;

    public Goal(string title, string description, int points)
    {
        _title = title;
        _description = description;
        _points = points;
    }

    public virtual void Display()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        Console.WriteLine($"{checkbox} {_title} ({_description})");
    }

    public abstract int RecordEvent();

    public abstract bool IsComplete();

    public virtual string GetSaveString()
    {
        return $"{_title}|{_description}|{_points}";
    }

    public int GetPoints()
    {
        return _points;
    }
}
