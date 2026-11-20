using System;

// EXCEEDING REQUIREMENTS:
// I added a fourth kind of goal called a NegativeGoal for bad habits. It is a
// derived class of Goal and overrides RecordEvent() to take points away instead
// of adding them. It is never completed. It can be created from the menu (option 4
// when creating a goal) and it is saved and loaded like the other goals.

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}
