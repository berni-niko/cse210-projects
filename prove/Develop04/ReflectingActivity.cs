// Derived class representing a reflecting activity
public class ReflectingActivity : Activity
{
    private List<string> _prompts; // List of prompts for reflection
    private List<string> _questions; // List of questions for reflection

    // Constructor for ReflectingActivity class
    public ReflectingActivity() : base("Reflecting Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };
        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }

    // Overrides the Run method to provide specific functionality for reflecting activity
    public override void Run()
    {
        DisplayStartingMessage();
      
        string prompt = GetRandomPrompt();
        Console.WriteLine(prompt);
        ShowSpinner(5);
        Console.WriteLine("Press enter once you've thought about the question.");
        Console.ReadLine();
        
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        int questionIndex = 0;

        while (DateTime.Now < endTime && questionIndex < _questions.Count)
        {
            string question = GetRandomQuestion();
            Console.WriteLine(question);
            ShowSpinner(5);
            Console.WriteLine("Press enter once you've thought about the question.");
            Console.ReadLine();
        }
        
        DisplayEndingMessage();
    }

    // Gets a random prompt from the list of prompts
    private string GetRandomPrompt()
    {
        Random random = new Random();
        return _prompts[random.Next(_prompts.Count)];
    }

    // Gets a random question from the list of questions
    private string GetRandomQuestion()
    {
        Random random = new Random();
        return _questions[random.Next(_questions.Count)];
    }
}