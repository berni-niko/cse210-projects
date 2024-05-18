// Base class representing a generic activity
public class Activity
{
    protected string _name; // Name of the activity
    protected string _description; // Description of the activity
    protected int _duration; // Duration of the activity in seconds

    // Constructor for Activity class
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    // Displays the starting message for the activity
    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Starting {_name}...");
        Console.WriteLine(_description);
        Console.Write("Enter duration (in seconds): ");
        _duration = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
    }

    // Displays the ending message for the activity
    public void DisplayEndingMessage()
    {
        Console.WriteLine("Good job!");
        ShowSpinner(2);
        Console.WriteLine($"You completed {_name} for {_duration} seconds.");
        ShowSpinner(3);
    }

    // Shows a spinner for a specified number of seconds
    protected void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    // Shows a countdown for a specified number of seconds
    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.WriteLine(i);
            Thread.Sleep(1000);
        }
    }

    // Virtual method to be overridden by derived classes
    public virtual void Run()
    {
        // This method will be overridden in derived classes
    }
}
