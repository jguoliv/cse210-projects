using System;

public class ChecklistGoal : Goal
{
    private int _numberCompleted;
    private int _numberTotal;
    private int _bonusPoints;

    public ChecklistGoal(string title, string description, int points, int numberTotal, int bonusPoints)
        : base(title, description, points)
    {
        _numberTotal = numberTotal;
        _bonusPoints = bonusPoints;
        _numberCompleted = 0;
    }

    public ChecklistGoal(string title, string description, int points, int numberTotal, int bonusPoints, int numberCompleted)
        : base(title, description, points)
    {
        _numberTotal = numberTotal;
        _bonusPoints = bonusPoints;
        _numberCompleted = numberCompleted;
    }

    public override int RecordEvent()
    {
        if (IsComplete())
        {
            return 0;
        }

        IncrementNumber();
        int points = GetPoints();

        if (IsComplete())
        {
            points += _bonusPoints;
        }

        return points;
    }

    public void IncrementNumber()
    {
        _numberCompleted++;
    }

    public override bool IsComplete()
    {
        return _numberCompleted >= _numberTotal;
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"    -- Currently completed: {_numberCompleted}/{_numberTotal}");
    }

    public override string GetSaveString()
    {
        return $"ChecklistGoal|{base.GetSaveString()}|{_numberTotal}|{_bonusPoints}|{_numberCompleted}";
    }
}
