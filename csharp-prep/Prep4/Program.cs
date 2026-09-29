using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int number = -1;

        List<int> numbers = new List<int>();

        while (number != 0)
        {
            Console.Write("Enter a number: ");
            number = int.Parse(Console.ReadLine());

            if (number != 0)
            {
                numbers.Add(number);
            }

        }
        
        int sum = 0;
        
        foreach (int value in numbers)
        {
            sum += value;
        }

        Console.WriteLine($"The sum is: {sum}");

        float average = ((float)sum) / numbers.Count;

        Console.WriteLine($"The average is: {average}");

        int largest = numbers[0];

        foreach (int value in numbers)
        {
            if (value > largest)
            {
                largest = value;
            }
        }

        Console.WriteLine($"The largest number is: {largest}");

    }
}