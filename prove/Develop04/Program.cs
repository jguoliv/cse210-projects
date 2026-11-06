using System;

// EXCEEDING REQUIREMENTS:
// I added an ActivityLog class that keeps a log of every activity the user
// completes (date, activity name, and seconds). From the menu the user can:
//   - view the log, including how many times each activity has been done,
//   - save the log to a file they name, and
//   - load a previously saved log file (a missing file shows a message
//     instead of crashing).
// Records are stored as one line each in the form: 2026-10-30|Breathing|60

class Program
{
    static void Main(string[] args)
    {
        ActivityLog log = new ActivityLog();
        string choice = "";

        while (choice != "7")
        {
            Console.Clear();
            ShowMenu();
            choice = Console.ReadLine();
            Console.Clear();

            if (choice == "1")
            {
                Breathing breathing = new Breathing();
                breathing.Run();
                log.AddRecord(breathing.GetName(), breathing.GetDuration());
            }
            else if (choice == "2")
            {
                Reflection reflection = new Reflection();
                reflection.Run();
                log.AddRecord(reflection.GetName(), reflection.GetDuration());
            }
            else if (choice == "3")
            {
                Listing listing = new Listing();
                listing.Run();
                log.AddRecord(listing.GetName(), listing.GetDuration());
            }
            else if (choice == "4")
            {
                log.DisplayLog();
                Pause();
            }
            else if (choice == "5")
            {
                Console.Write("Enter a filename to save to: ");
                log.SaveLog(Console.ReadLine());
                Pause();
            }
            else if (choice == "6")
            {
                Console.Write("Enter a filename to load: ");
                log.LoadLog(Console.ReadLine());
                Pause();
            }
            else if (choice != "7")
            {
                Console.WriteLine("Please choose a number from 1 to 7.");
                Pause();
            }
        }

        Console.WriteLine("Goodbye!");
    }

    static void ShowMenu()
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine("  1. Start breathing activity");
        Console.WriteLine("  2. Start reflecting activity");
        Console.WriteLine("  3. Start listing activity");
        Console.WriteLine("  4. View activity log");
        Console.WriteLine("  5. Save log to a file");
        Console.WriteLine("  6. Load log from a file");
        Console.WriteLine("  7. Quit");
        Console.Write("Select a choice from the menu: ");
    }

    static void Pause()
    {
        Console.WriteLine();
        Console.Write("Press Enter to return to the menu. ");
        Console.ReadLine();
    }
}
