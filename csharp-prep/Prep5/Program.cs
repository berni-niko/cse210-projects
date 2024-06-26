using System;

class Program
{
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine(); // Returns the user's name
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine()); // Returns the user's favorite number
    }

    static int SquareNumber(int number)
    {
        return number * number; // Returns the square of the number
    }

    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}.");
    }

    static void Main(string[] args)
    {
        DisplayWelcome(); // Display the welcome message

        string userName = PromptUserName(); // Get the user's name
        int userNumber = PromptUserNumber(); // Get the user's favorite number
        int squaredNumber = SquareNumber(userNumber); // Square the user's number

        DisplayResult(userName, squaredNumber); // Display the result
    }
}