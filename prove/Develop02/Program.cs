using System;
using System.Collections.Generic;
using System.IO;

// The Program class acts as the entry point for the application.
class Program
{
    // Main method - starting point of the program.
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool running = true;

        // Main loop of the application, presenting menu options until the user chooses to exit.
        while (running)
        {
            Console.WriteLine("Journal Application");
            Console.WriteLine("1. Write New Entry");
            Console.WriteLine("2. Display Journal");
            Console.WriteLine("3. Save Journal to File");
            Console.WriteLine("4. Load Journal from File");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");
            string option = Console.ReadLine();

            // Switch statement to handle user input.
            switch (option)
            {
                case "1": // Option to write a new journal entry.
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"Today's Prompt: {prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();
                    string date = DateTime.Now.ToString("yyyy-MM-dd");
                    Entry entry = new Entry(date, prompt, response);
                    journal.AddEntry(entry);
                    break;
                case "2": // Option to display all journal entries.
                    journal.DisplayAll();
                    break;
                case "3": // Option to save the journal to a file.
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;
                case "4": // Option to load the journal from a file.
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;
                case "5": // Option to exit the program.
                    running = false;
                    break;
                default: // Handler for invalid input.
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }
}

// The Journal class manages a collection of journal entries.
public class Journal
{
    private List<Entry> _entries; // Private field to store journal entries.

    // Constructor to initialize the Journal object.
    public Journal()
    {
        _entries = new List<Entry>();
    }

    // Method to add a new entry to the journal.
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    // Method to display all entries in the journal.
    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    // Method to save the journal to a file.
    public void SaveToFile(string file)
    {
        using (StreamWriter writer = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.PromptText}|{entry.EntryText}");
            }
        }
    }

    // Method to load the journal from a file.
    public void LoadFromFile(string file)
    {
        _entries.Clear();
        using (StreamReader reader = new StreamReader(file))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    AddEntry(new Entry(parts[0], parts[1], parts[2]));
                }
            }
        }
    }
}

// The Entry class represents a single journal entry.
public class Entry
{
    public string Date { get; set; } // Public property for the date of the entry.
    public string PromptText { get; set; } // Public property for the prompt text of the entry.
    public string EntryText { get; set; } // Public property for the text of the entry.

    // Constructor to create a new entry with specified date, prompt, and text.
    public Entry(string date, string prompt, string text)
    {
        Date = date;
        PromptText = prompt;
        EntryText = text;
    }

    // Method to display the entry in a formatted way.
    public void Display()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {PromptText}");
        Console.WriteLine($"Entry: {EntryText}");
        Console.WriteLine("------------------------------");
    }
}

// The PromptGenerator class is responsible for generating random prompts for journal entries.
public class PromptGenerator
{
    private List<string> _prompts; // Private field to store a list of possible prompts.

    // Constructor to initialize the PromptGenerator with a set of predefined prompts.
    public PromptGenerator()
    {
        _prompts = new List<string>()
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };
    }

    // Method to get a random prompt from the list.
    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}

