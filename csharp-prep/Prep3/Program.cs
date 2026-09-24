using System;

class Program
{
    static void Main(string[] args)
    {
        
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 20);

        Console.Write("What is the magic number? ");
        // string magicNumberInput = Console.ReadLine();
        // int magicNumber = int.Parse(magicNumberInput);

        int guess = -1;
        
        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            // string guessInput = Console.ReadLine();
            // guess = int.Parse(guessInput);
            guess = int.Parse(Console.ReadLine());
            
            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
    }
}