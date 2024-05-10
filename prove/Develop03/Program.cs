using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Initialize a library of scriptures
        ScriptureLibrary scriptureLibrary = new ScriptureLibrary();
        scriptureLibrary.AddScripture(new Scripture(new Reference("John", 3, 16), "For God so loved the world that He gave His only begotten Son, that whoever believes in Him should not perish but have everlasting life."));
        scriptureLibrary.AddScripture(new Scripture(new Reference("Psalm", 23, 1), "The Lord is my shepherd; I shall not want."));
        scriptureLibrary.AddScripture(new Scripture(new Reference("Matthew", 5, 9), "Blessed are the peacemakers: for they shall be called the children of God."));

        Console.WriteLine("Press Enter to hide words or type 'quit' to exit.");
        Scripture scripture = scriptureLibrary.GetRandomScripture();

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
                break;
            scripture.HideRandomWords(3);
        }

        Console.WriteLine("All words are hidden!");
    }
}

public class ScriptureLibrary
{
    private List<Scripture> _scriptures = new List<Scripture>();
    private Random _random = new Random();

    public void AddScripture(Scripture scripture)
    {
        _scriptures.Add(scripture);
    }

    public Scripture GetRandomScripture()
    {
        int index = _random.Next(_scriptures.Count);
        return _scriptures[index];
    }
}

