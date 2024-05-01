using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Define a class representing a journal entry
public class JournalEntry 
{
    // Attributes: Prompt, Response, and Date
    public string _prompt { get; set; } // Prompt for the journal entry
    public string _response { get; set; } // Response to the prompt
    public string _date { get; set; } // Date when the entry was created

    // Constructor to create a journal entry with a prompt, response, and current date
    public JournalEntry(string prompt, string response) 
    {
        _prompt = prompt;
        _response = response;
        _date = DateTime.Now.ToString("yyyy-MM-dd"); // Date is set to current date
    }

    // Behavior: Override ToString to display the entry in a formatted manner
    public override string ToString() 
    {
        return $"[{_date}] {_prompt}: {_response}";
    }
}

// Define a class representing a journal
public class Journal 
{
    // Attributes: List of journal entries
    private List<JournalEntry> _entries = new List<JournalEntry>();

    // Behavior: Method to add a new entry to the journal
    public void AddEntry(JournalEntry entry) 
    {
        _entries.Add(entry);
    }

    // Behavior: Method to delete an entry from the journal based on index
    public void DeleteEntry(int index) 
    {
        if (index < 0 || index >= _entries.Count) // Behavior: Check if index is valid
        {
            throw new IndexOutOfRangeException("Invalid index");
        }
        _entries.RemoveAt(index);
    }

    // Behavior: Method to get all entries in the journal
    public List<JournalEntry> GetEntries() 
    {
        return _entries;
    }

    // Behavior: Method to display all entries in the journal
    public void DisplayEntries() 
    {
        if (_entries.Count == 0) 
        {
            Console.WriteLine("No entries found.");
        } 
        else 
        {
            foreach (JournalEntry entry in _entries) 
            {
                Console.WriteLine(entry);
            }
        }
    }

    // Behavior: Method to save journal entries to a file
    public void SaveToFile(string filename) 
    {
        using (StreamWriter writer = new StreamWriter(filename)) 
        {
            foreach (JournalEntry entry in _entries) 
            {
                // Format and write each entry to the file
                string formattedResponse = entry._response.Replace("|", "\\|").Replace("\"", "\\\"");
                writer.WriteLine($"{entry._date}|{entry._prompt}|\"{formattedResponse}\"");
            }
        }
    }

    // Behavior: Method to load journal entries from a file
    public void LoadFromFile(string filename) 
    {
        _entries.Clear(); // Clear existing entries
        using (StreamReader reader = new StreamReader(filename)) 
        {
            string line;
            while ((line = reader.ReadLine()) != null) 
            {
                // Split each line into parts using '|' separator
                string[] parts = line.Split('|');
                if (parts.Length >= 3) 
                {
                    // Reconstruct the response and create a new journal entry
                    string response = parts[2].Replace("\\|", "|").Replace("\\\"", "\"");
                    JournalEntry entry = new JournalEntry(parts[1], response);
                    entry._date = parts[0]; // Set the date
                    AddEntry(entry); // Add the entry to the journal
                }
            }
        }
    }

    // Behavior: Method to sort journal entries by date
    public void SortEntriesByDate() 
    {
        _entries = _entries.OrderBy(e => e._date).ToList(); // Sort entries by date
    }
}

// Define a class representing the journal application
public class JournalApp 
{
    private Journal journal; // Instance of the Journal class
    private Random random; // Random number generator
    private List<string> prompts; // List of prompts for journal entries

    // Constructor to initialize the journal app
    public JournalApp() 
    {
        journal = new Journal(); // Initialize the journal
        random = new Random(); // Initialize the random number generator
        prompts = new List<string> // Initialize the list of prompts
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };
    }

    // Behavior: Method to run the journal application
    public void Run() 
    {
        bool running = true;
        while (running) 
        {
            ShowMenu(); // Behavior: Display the menu
            string choice = Console.ReadLine(); // Behavior: Read user choice

            switch (choice) 
            {
                case "1":
                    WriteNewEntry(); // Behavior: Add a new entry
                    break;
                case "2":
                    DisplayJournal(); // Behavior: Display all entries
                    break;
                case "3":
                    SaveJournal(); // Behavior: Save entries to a file
                    break;
                case "4":
                    LoadJournal(); // Behavior: Load entries from a file
                    break;
                case "5":
                    running = false; // Behavior: Exit the application
                    break;
                case "6":
                    DeleteEntry(); // Behavior: Delete an entry
                    break;
                case "7":
                    SortJournalByDate(); // Behavior: Sort entries by date
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again."); // Behavior: Invalid choice
                    break;
            }
        }
    }

    // Behavior: Method to display the menu options
    private void ShowMenu() 
    {
        Console.WriteLine("Journal Program");
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display the journal");
        Console.WriteLine("3. Save the journal");
        Console.WriteLine("4. Load the journal");
        Console.WriteLine("5. Exit");
        Console.WriteLine("6. Delete an entry");
        Console.WriteLine("7. Sort journal by date");
        Console.Write("Choose an option: ");
    }

    // Behavior: Method to write a new journal entry
    private void WriteNewEntry() 
    {
        int index = random.Next(prompts.Count); // Behavior: Randomly select a prompt
        string prompt = prompts[index]; // Behavior: Get the prompt
        Console.WriteLine(prompt); // Behavior: Display the prompt
        Console.Write("Your response: ");
        string response = Console.ReadLine(); // Behavior: Get the response from the user

        if (string.IsNullOrEmpty(response)) // Behavior: Check if response is empty
        {
            Console.WriteLine("Invalid response. Try again.");
            return;
        }

        JournalEntry newEntry = new JournalEntry(prompt, response); // Behavior: Create a new entry
        journal.AddEntry(newEntry); // Behavior: Add the entry to the journal

        Console.WriteLine("Journal entry created successfully.");
    }

    // Behavior: Method to display all journal entries
    private void DisplayJournal() 
    {
        Console.WriteLine("All Journal Entries:");
        journal.DisplayEntries(); // Behavior: Display all entries
    }

    // Behavior: Method to save journal entries to a file
    private void SaveJournal() 
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine(); // Behavior: Get the filename from user
        if (string.IsNullOrEmpty(filename)) 
        {
            Console.WriteLine("Invalid filename. Try again.");
            return;
        }
        journal.SaveToFile(filename); // Behavior: Save entries to file
        Console.WriteLine("Journal saved successfully.");
    }

    // Behavior: Method to load journal entries from a file
    private void LoadJournal() 
    {
        Console.WriteLine("Enter filename to load:");
        string filename = Console.ReadLine(); // Behavior: Get the filename from user
        if (string.IsNullOrEmpty(filename)) 
        {
            Console.WriteLine("Invalid filename. Try again.");
            return;
        }
        journal.LoadFromFile(filename); // Behavior: Load entries from file
        Console.WriteLine("Journal loaded successfully.");
    }

    // Behavior: Method to delete a journal entry
    private void DeleteEntry() 
    {
        Console.WriteLine("Enter index of the entry to delete:");
        if (int.TryParse(Console.ReadLine(), out int index)) // Behavior: Get index from user
        {
            try 
            {
                journal.DeleteEntry(index - 1); // Behavior: Delete the entry
                Console.WriteLine("Entry deleted successfully.");
            } catch (IndexOutOfRangeException) 
            {
                Console.WriteLine("Invalid index. Try again.");
            }
        } 
        else 
        {
            Console.WriteLine("Invalid input. Try again.");
        }
    }

    // Behavior: Method to sort journal entries by date
    private void SortJournalByDate() 
    {
        journal.SortEntriesByDate(); // Behavior: Sort entries by date
        Console.WriteLine("Journal sorted by date.");
    }
}

// Main class to run the program
public class Program 
{
    public static void Main() 
    {
        JournalApp app = new JournalApp(); // Object: Create an instance of the journal app
        app.Run(); // Behavior: Run the journal app
    }
}
