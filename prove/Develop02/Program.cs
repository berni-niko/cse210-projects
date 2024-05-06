using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

//Attempted the stretch challenge


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
            Console.WriteLine("3. Save Journal to CSV");
            Console.WriteLine("4. Load Journal from CSV");
            Console.WriteLine("5. Save Journal to JSON");
            Console.WriteLine("6. Load Journal from JSON");
            Console.WriteLine("7. Exit");
            Console.Write("Select an option: ");
            string option = Console.ReadLine();

            // Switch statement to handle user input. https://www.youtube.com/watch?v=Qs-LAYkp9YU&t=7s Starts from 6:57min
            switch (option)
            {
                 case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"Today's Prompt: {prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();
                    Console.Write("Your mood (e.g., Happy, Sad, Neutral): ");
                    string mood = Console.ReadLine();
                    string date = DateTime.Now.ToString("yyyy-MM-dd");
                    Entry entry = new Entry(date, prompt, response, mood);
                    journal.AddEntry(entry);
                    break;
                case "2":
                    journal.DisplayAll();
                    break;
                case "3":
                    Console.Write("Enter filename to save as CSV: ");
                    string csvFile = Console.ReadLine();
                    journal.SaveToCSV(csvFile);
                    break;
                case "4":
                    Console.Write("Enter filename to load from CSV: ");
                    string loadCsvFile = Console.ReadLine();
                    journal.LoadFromCSV(loadCsvFile);
                    break;
                case "5":
                    Console.Write("Enter filename to save as JSON: ");
                    string jsonFile = Console.ReadLine();
                    journal.SaveToJson(jsonFile);
                    break;
                case "6":
                    Console.Write("Enter filename to load from JSON: ");
                    string loadJsonFile = Console.ReadLine();
                    journal.LoadFromJson(loadJsonFile);
                    break;
                case "7":
                    running = false;
                    break;
                default:
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
    public void SaveToCSV(string file)
    {
        using (StreamWriter writer = new StreamWriter(file))
        {
            writer.WriteLine("Date,Prompt,Mood,Entry");
            foreach (Entry entry in _entries)
            {
                // Escape quotes and commas
                string escapedEntry = entry.EntryText.Replace("\"", "\"\"");
                writer.WriteLine($"\"{entry.Date}\",\"{entry.PromptText}\",\"{entry.Mood}\",\"{escapedEntry}\"");
            }
        }
    }

    // Method to load the journal from a file.
    public void LoadFromCSV(string file)
    {
        _entries.Clear();
        using (StreamReader reader = new StreamReader(file))
        {
            reader.ReadLine(); // Skip header
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(new char[] { ',' }, 4);
                if (parts.Length == 4)
                {
                    // Unescape quotes
                    string entryText = parts[3].Trim('"').Replace("\"\"", "\"");
                    AddEntry(new Entry(parts[0].Trim('"'), parts[1].Trim('"'), entryText, parts[2].Trim('"')));
                }
            }
        }
    }
        // Save journal entries to a JSON file
    public void SaveToJson(string file)
    {
        string json = JsonConvert.SerializeObject(_entries, Formatting.Indented);
        File.WriteAllText(file, json);
    }

    // Load journal entries from a JSON file
    public void LoadFromJson(string file)
    {
        string json = File.ReadAllText(file);
        _entries = JsonConvert.DeserializeObject<List<Entry>>(json) ?? new List<Entry>();
    }
}

// The Entry class represents a single journal entry.
public class Entry
{
    public string Date { get; set; } // Public property for the date of the entry.
    public string PromptText { get; set; } // Public property for the prompt text of the entry.
    public string EntryText { get; set; } // Public property for the text of the entry.
    public string Mood { get; set; } // Public property to track the mood

    // Constructor to create a new entry with specified date, prompt, and text.
    public Entry(string date, string prompt, string text, string mood)
    {
        Date = date;
        PromptText = prompt;
        EntryText = text;
        Mood = mood;
    }

    // Method to display the entry in a formatted way.
    public void Display()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {PromptText}");
        Console.WriteLine($"Mood: {Mood}");
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

