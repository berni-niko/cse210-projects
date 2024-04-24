using System;

class Program
{
    static void Main(string[] args)
    {
       Random random = new Random();
        int magicNumber = random.Next(1, 101); // Generate a random number between 1 and 100

        Console.WriteLine("Welcome to Guess My Number!");

        int guess = 0; // Initialize the guess variable
        while (guess != magicNumber) // Loop until the correct guess
        {
            Console.Write("What is your guess? ");
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
