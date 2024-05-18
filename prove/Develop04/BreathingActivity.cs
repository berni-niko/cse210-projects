// Derived class representing a breathing activity
public class BreathingActivity : Activity
{
    // Constructor for BreathingActivity class
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.") 
    { }

    // Overrides the Run method to provide specific functionality for breathing activity
    public override void Run()
    {
        DisplayStartingMessage();
        
        for (int i = 0; i < _duration; i += 4)
        {
            Console.WriteLine("Breathe in...");
            ShowCountDown(5);
            Console.WriteLine("Breathe out...");
            ShowCountDown(5);
        }
        
        DisplayEndingMessage();
    }
}
