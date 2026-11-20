using System;

// EXCEEDING REQUIREMENTS:
// 1. Leveling system: every 1000 points raises the user one level, and each level
//    has a rank title (Beginner, Seeker, Disciple, Pathfinder, Champion, Guardian,
//    Legend). The level and rank show with the score, and a "LEVEL UP!" message
//    appears when recording an event pushes the user to a new level.
// 2. Negative goals: a fourth kind of goal (NegativeGoal) for bad habits. Recording
//    one takes points away instead of adding them, and it is never completed.
//    It can be created from the menu and is saved and loaded like the other goals.
// 3. Safer input: numbers are checked so a typo does not crash the program, a
//    missing or invalid save file shows a message, and the | character is replaced
//    in goal text so it cannot break the save file.

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}
