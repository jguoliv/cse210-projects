using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        string choice = "";

        while (choice != "6")
        {
            Console.WriteLine();
            ShowScore();
            ShowMenu();
            choice = Console.ReadLine();
            Console.WriteLine();

            if (choice == "1")
            {
                CreateGoal();
            }
            else if (choice == "2")
            {
                ListGoals();
            }
            else if (choice == "3")
            {
                Console.Write("What is the filename for the goal file? ");
                SaveGoals(Console.ReadLine());
            }
            else if (choice == "4")
            {
                Console.Write("What is the filename for the goal file? ");
                LoadGoals(Console.ReadLine());
            }
            else if (choice == "5")
            {
                RecordGoalEvent();
            }
            else if (choice != "6")
            {
                Console.WriteLine("Please choose a number from 1 to 6.");
            }
        }

        Console.WriteLine("Keep up the good work on your Eternal Quest!");
    }

    public void ShowMenu()
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine("  1. Create new goal");
        Console.WriteLine("  2. List goals");
        Console.WriteLine("  3. Save goals");
        Console.WriteLine("  4. Load goals");
        Console.WriteLine("  5. Record event");
        Console.WriteLine("  6. Quit");
        Console.Write("Select a choice from the menu: ");
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.WriteLine("  4. Negative Goal (a bad habit that costs points)");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        if (type != "1" && type != "2" && type != "3" && type != "4")
        {
            Console.WriteLine("That is not a goal type.");
            return;
        }

        string title = ReadText("What is the name of your goal? ");
        string description = ReadText("What is a short description of it? ");
        int points = ReadNumber("What is the amount of points associated with this goal? ");

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(title, description, points));
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(title, description, points));
        }
        else if (type == "3")
        {
            int total = ReadNumber("How many times does this goal need to be accomplished for a bonus? ");
            int bonus = ReadNumber("What is the bonus for accomplishing it that many times? ");
            _goals.Add(new ChecklistGoal(title, description, points, total, bonus));
        }
        else
        {
            _goals.Add(new NegativeGoal(title, description, points));
        }

        Console.WriteLine("Goal created!");
    }

    public void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals yet.");
            return;
        }

        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            _goals[i].Display();
        }
    }

    public void RecordGoalEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals yet. Create one first.");
            return;
        }

        ListGoals();
        Console.Write("Which goal did you accomplish? ");
        int number;

        if (!int.TryParse(Console.ReadLine(), out number) || number < 1 || number > _goals.Count)
        {
            Console.WriteLine("That is not a goal on the list.");
            return;
        }

        int points = _goals[number - 1].RecordEvent();
        _score += points;

        if (points > 0)
        {
            Console.WriteLine($"Congratulations! You have earned {points} points!");
        }
        else if (points < 0)
        {
            Console.WriteLine($"Oh no! You lost {-points} points. Tomorrow is a new day!");
        }
        else
        {
            Console.WriteLine("That goal is already complete, so no points were earned.");
        }

        Console.WriteLine($"You now have {_score} points.");
    }

    public void ShowScore()
    {
        Console.WriteLine($"You have {_score} points.");
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetSaveString());
            }
        }

        Console.WriteLine($"Saved {_goals.Count} goal(s) to {filename}.");
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine($"The file {filename} was not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        List<Goal> loadedGoals = new List<Goal>();
        int loadedScore;

        if (lines.Length == 0 || !int.TryParse(lines[0], out loadedScore))
        {
            Console.WriteLine("That file is not a valid goal file.");
            return;
        }

        for (int i = 1; i < lines.Length; i++)
        {
            Goal goal = CreateGoalFromLine(lines[i]);

            if (goal != null)
            {
                loadedGoals.Add(goal);
            }
        }

        _score = loadedScore;
        _goals = loadedGoals;
        Console.WriteLine($"Loaded {_goals.Count} goal(s) from {filename}.");
    }

    private Goal CreateGoalFromLine(string line)
    {
        string[] parts = line.Split("|");

        try
        {
            string type = parts[0];
            string title = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);

            if (type == "SimpleGoal")
            {
                return new SimpleGoal(title, description, points, bool.Parse(parts[4]));
            }
            else if (type == "EternalGoal")
            {
                return new EternalGoal(title, description, points);
            }
            else if (type == "NegativeGoal")
            {
                return new NegativeGoal(title, description, points);
            }
            else if (type == "ChecklistGoal")
            {
                return new ChecklistGoal(title, description, points, int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]));
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Skipped a line that could not be read.");
        }

        return null;
    }

    private string ReadText(string prompt)
    {
        Console.Write(prompt);
        string text = Console.ReadLine();

        // The | character separates values in the save file, so it cannot be used in text.
        return text.Replace("|", "/");
    }

    private int ReadNumber(string prompt)
    {
        int number;
        Console.Write(prompt);

        while (!int.TryParse(Console.ReadLine(), out number) || number < 0)
        {
            Console.Write("Please enter a whole number (0 or more): ");
        }

        return number;
    }
}
