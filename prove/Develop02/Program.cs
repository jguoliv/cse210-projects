using System;

class Program
{
    // Extra feature to exceed requirements: each entry also records the user's mood, which is displayed and saved to and loaded from the file.
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        Console.WriteLine("");
        Console.WriteLine("Welcome to the Journal Program!");

        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine("");
            Console.WriteLine("Please select one of the following choices: ");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            choice = int.Parse(Console.ReadLine());
            Console.WriteLine("");

            if (choice == 1)
            {
                DateTime todaysDate = DateTime.Now;
                string date = todaysDate.ToShortDateString();

                Console.WriteLine("How are you feeling today?");
                string mood = Console.ReadLine();
                Console.WriteLine("");

                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(prompt);
                string response = Console.ReadLine();

                myJournal.AddEntry(date, mood, prompt, response);
            }

            if (choice == 2)
            {
                myJournal.DisplayEntries();
            }

            if (choice == 3)
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                myJournal.LoadJournal(filename);
            }

            if (choice == 4)
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                myJournal.SaveJournal(filename);
            }
        }
    }
}