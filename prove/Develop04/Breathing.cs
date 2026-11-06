using System;

public class Breathing : BaseActivity
{
    public Breathing() : base(
        "Breathing",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        ShowPrologue();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        while (DateTime.Now < endTime)
        {
            BreatheIn();
            BreatheOut();
        }

        ShowEpilogue();
    }

    public void BreatheIn()
    {
        Console.Write("Breathe in... ");
        ShowCountDown(4);
        Console.WriteLine();
    }

    public void BreatheOut()
    {
        Console.Write("Now breathe out... ");
        ShowCountDown(6);
        Console.WriteLine();
        Console.WriteLine();
    }
}
