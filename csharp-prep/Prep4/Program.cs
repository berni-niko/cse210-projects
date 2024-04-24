using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>(); // Create a list to store the numbers
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int input;
        do
        {
            Console.Write("Enter number: ");
            input = int.Parse(Console.ReadLine());

            if (input != 0) // Append to the list if it's not zero
            {
                numbers.Add(input);
            }
        } while (input != 0); // Continue until the user inputs 0

        // Compute the sum of the numbers
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"The sum is: {sum}");

        // Compute the average of the numbers
        double average = sum / (double)numbers.Count; // Cast to double for accurate division
        Console.WriteLine($"The average is: {average}");

        // Find the maximum number in the list
        int max = int.MinValue;
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        Console.WriteLine($"The largest number is: {max}");
    }
}