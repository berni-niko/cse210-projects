using System; // Importing the System namespace for basic functionalities
using System.Collections.Generic; // Importing the System.Collections.Generic namespace for using List<T>

class Program
{
    static void Main(string[] args)
    {
        // Initialize a library of scriptures
        ScriptureLibrary scriptureLibrary = new ScriptureLibrary(); // Creating an instance of the ScriptureLibrary class
        // Adding scriptures to the library
        scriptureLibrary.AddScripture(new Scripture(new Reference("John", 3, 16), "For God so loved the world that He gave His only begotten Son, that whoever believes in Him should not perish but have everlasting life."));
        scriptureLibrary.AddScripture(new Scripture(new Reference("Psalm", 23, 1), "The Lord is my shepherd; I shall not want."));
        scriptureLibrary.AddScripture(new Scripture(new Reference("Matthew", 5, 9), "Blessed are the peacemakers: for they shall be called the children of God."));

        Console.WriteLine("Press Enter to hide words or type 'quit' to exit."); // Prompting the user for input

        // Get a random scripture from the library
        Scripture scripture = scriptureLibrary.GetRandomScripture();

        // Loop until all words in the scripture are hidden or user types 'quit'
        while (!scripture.IsCompletelyHidden()) // Loop until all words in the scripture are hidden or user types 'quit'
        {
            Console.Clear(); // Clearing the console to display the scripture without previously displayed text
            Console.WriteLine(scripture.GetDisplayText()); // Displaying the scripture text with hidden words
            string input = Console.ReadLine(); // Reading user input
            if (input.ToLower() == "quit" || scripture.IsCompletelyHidden()) // Checking if the user wants to quit or all words are hidden
                break; // Exiting the loop if the user types 'quit' or all words are hidden
            scripture.HideRandomWords(3); // Hiding 3 random words in the scripture
        }

        Console.WriteLine("All words are hidden!"); // Informing the user that all words are hidden or the user quit
    }
}

// Class representing a library of scriptures
public class ScriptureLibrary
{
    private List<Scripture> _scriptures = new List<Scripture>(); // List to store scriptures
    private Random _random = new Random(); // Random number generator for selecting random scriptures

    // Method to add a scripture to the library
    public void AddScripture(Scripture scripture)
    {
        _scriptures.Add(scripture); // Adding the scripture to the list
    }

    // Method to get a random scripture from the library
    public Scripture GetRandomScripture()
    {
        int index = _random.Next(_scriptures.Count); // Generating a random index within the range of available scriptures
        return _scriptures[index]; // Returning the scripture at the randomly selected index
    }
}
