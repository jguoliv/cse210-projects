using System;
using System.Collections.Generic;
using System.IO;

public class ActivityLog
{
    private List<string> _records;

    public ActivityLog()
    {
        _records = new List<string>();
    }

    public void AddRecord(string activityName, int duration)
    {
        string date = DateTime.Now.ToString("yyyy-MM-dd");
        _records.Add($"{date}|{activityName}|{duration}");
    }

    public int GetCount(string activityName)
    {
        int count = 0;

        foreach (string record in _records)
        {
            string[] parts = record.Split("|");
            if (parts.Length == 3 && parts[1] == activityName)
            {
                count++;
            }
        }

        return count;
    }

    public void DisplayLog()
    {
        Console.WriteLine("Activity Log");
        Console.WriteLine("------------");

        if (_records.Count == 0)
        {
            Console.WriteLine("No activities have been logged yet.");
        }
        else
        {
            foreach (string record in _records)
            {
                string[] parts = record.Split("|");
                if (parts.Length == 3)
                {
                    Console.WriteLine($"{parts[0]}  {parts[1]}  ({parts[2]} seconds)");
                }
            }
        }

        Console.WriteLine();
        Console.WriteLine($"Breathing: {GetCount("Breathing")} time(s)");
        Console.WriteLine($"Reflection: {GetCount("Reflection")} time(s)");
        Console.WriteLine($"Listing: {GetCount("Listing")} time(s)");
    }

    public void SaveLog(string filename)
    {
        File.WriteAllLines(filename, _records);
        Console.WriteLine($"Saved {_records.Count} record(s) to {filename}.");
    }

    public void LoadLog(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine($"The file {filename} was not found.");
            return;
        }

        _records = new List<string>(File.ReadAllLines(filename));
        Console.WriteLine($"Loaded {_records.Count} record(s) from {filename}.");
    }
}
