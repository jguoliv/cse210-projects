using System;
using System.Diagnostics.CodeAnalysis;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your first name? ");
        String firstName = Console.ReadLine();

        Console.Write("What is your last name? ");
        String lastName = Console.ReadLine();

        Console.Write($"your name is {lastName}, {firstName} {lastName}.");
    }
}