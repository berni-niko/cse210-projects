// Derived class representing a listing activity
public class ListingActivity : Activity
{
    private int _count; // Count of listed items
    private List<string> _prompts; // List of prompts for listing items

    // Constructor for ListingActivity class
    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    // Overrides the Run method to provide specific functionality for listing activity
    public override void Run()
    {
        DisplayStartingMessage();
        
        string prompt = GetRandomPrompt();
        Console.WriteLine(prompt);
        ShowSpinner(3);
        Console.WriteLine("Start listing items...");
        
        _count = 0;
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item)) _count++;
        }
        
        Console.WriteLine($"You listed {_count} items.");
        DisplayEndingMessage();
    }

    // Gets a random prompt from the list of prompts
    private string GetRandomPrompt()
    {
        Random random = new Random();
        return _prompts[random.Next(_prompts.Count)];
    }
}