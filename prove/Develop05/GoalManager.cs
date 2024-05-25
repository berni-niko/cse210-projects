public class GoalManager
{   
    // Private fields to store the list of goals and the current score
    private List<Goal> _goals;
    private int _score;

    // Constructor to initialize the GoalManager
    public GoalManager()
    {   
        
        _goals = new List<Goal>(); // Initialize the list of goals
        _score = 0; // Initialize the score to 0
    }

    // Method to start the goal management program
    public void Start()
    {   
        // Infinite loop to keep the program running until the user exits
        while (true)
        {   
            // Display the menu options
            DisplayMenu();
            string choice = Console.ReadLine(); // Read the user's choice

            switch (choice) // Handle the user's choice
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    SaveGoals("goals.txt");
                    break;
                case "4":
                    LoadGoals("goals.txt");
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    return; // Exit the program
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    // Private method to display the menu options
    private void DisplayMenu()
    {
        Console.WriteLine();
        Console.WriteLine("Eternal Quest Program");
        Console.WriteLine($"Current Score: {_score}");
        Console.WriteLine();
        Console.WriteLine("1. Create New Goal");
        Console.WriteLine("2. List Goals");
        Console.WriteLine("3. Save Goals");
        Console.WriteLine("4. Load Goals");
        Console.WriteLine("5. Record Event");
        Console.WriteLine("6. Exit");
        Console.Write("Enter your choice: ");
    }

    // Private method to create a new goal
    private void CreateGoal()
{
    string goalTypeChoice = null;

    // Loop until a valid goal type is entered
    while (true)
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        goalTypeChoice = Console.ReadLine().Trim();

        if (goalTypeChoice == "1" || goalTypeChoice == "2" || goalTypeChoice == "3")
        {
            break;
        }
        else
        {
            Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
        }
    }

    
    Console.WriteLine($"You selected: {goalTypeChoice}");

    Console.Write("What is the name of your goal? ");
    string name = Console.ReadLine();

    Console.Write("What is a short description of it? ");
    string description = Console.ReadLine();

    Console.Write("What is the amount of points associated with this goal? ");
    int points = int.Parse(Console.ReadLine());

    Goal newGoal = null;
    switch (goalTypeChoice)
    {
        case "1":
            newGoal = new SimpleGoal(name, description, points);
            break;
        case "2":
            newGoal = new EternalGoal(name, description, points);
            break;
        case "3":
            Console.Write("What is the target amount for the goal? ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("What is the bonus for completing the target? ");
            int bonus = int.Parse(Console.ReadLine());
            newGoal = new ChecklistGoal(name, description, points, target, bonus);
            break;
    }

    if (newGoal != null)
    {
        _goals.Add(newGoal);
        Console.WriteLine("Goal created successfully.");
    }
}


    // Private method to list all goals
    private void ListGoals()
    {   
        // Check if there are no goals
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
            return;
        }

        // Display each goal's string representation
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetStringRepresentation());
        }
    }

    // Private method to save goals to a file
    private void SaveGoals(string fileName)
    {   
        // Use StreamWriter to write to the specified file
        using (StreamWriter writer = new StreamWriter(fileName))
        {   
            // Write the current score to the file
            writer.WriteLine(_score);
            // Write each goal's data to the file
            foreach (var goal in _goals)
            {
                string goalType = goal.GetType().Name;
                string goalData = $"{goalType}|{goal.ShortName}|{goal.Description}|{goal.Points}";

                // Add additional data based on the goal type
                if (goal is SimpleGoal simpleGoal)
                {
                    goalData += $"|{simpleGoal.IsComplete()}";
                }
                else if (goal is EternalGoal)
                {
                   
                }
                else if (goal is ChecklistGoal checklistGoal)
                {
                    goalData += $"|{checklistGoal.Target}|{checklistGoal.Bonus}|{checklistGoal.AmountCompleted}";
                }

                writer.WriteLine(goalData);
            }
        }
    }

    // Public method to load goals from a file
    public void LoadGoals(string fileName)
    {   
        // Use StreamReader to read from the specified file
        using (StreamReader reader = new StreamReader(fileName))
        {   
            // Read and set the current score
            // Converts this line to an integer and assigns it to the _score variable
            _score = int.Parse(reader.ReadLine());
            // Clears the current list of goals to ensure that the list is empty before loading new goals from the file.
            _goals.Clear();

            string line;
            // Read each line and recreate the goals
            // Reads each subsequent line from the file until the end of the file is reached (null).
            //Each line represents a serialized goal.
            while ((line = reader.ReadLine()) != null)
            {   
                // Splits the line into parts using the | character as the delimiter.
                // Each part represents a different piece of information about the goal (e.g., type, name, description, points, etc.). 
                string[] parts = line.Split('|');
                string goalType = parts[0];
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);

                // Handling Different Goal Types
                // The method handles different goal types (SimpleGoal, EternalGoal, ChecklistGoal) by checking the goalType string and creating the appropriate goal object.
                if (goalType == nameof(SimpleGoal))
                {
                    bool isComplete = bool.Parse(parts[4]);
                    SimpleGoal goal = new SimpleGoal(name, description, points);
                    if (isComplete) goal.RecordEvent(); 
                    _goals.Add(goal);
                }
                else if (goalType == nameof(EternalGoal))
                {
                    EternalGoal goal = new EternalGoal(name, description, points);
                    _goals.Add(goal);
                }
                else if (goalType == nameof(ChecklistGoal))
                {
                    int target = int.Parse(parts[4]);
                    int bonus = int.Parse(parts[5]);
                    int amountCompleted = int.Parse(parts[6]);
                    ChecklistGoal goal = new ChecklistGoal(name, description, points, target, bonus);
                    for (int i = 0; i < amountCompleted; i++) goal.RecordEvent();
                    _goals.Add(goal);
                }
            }
        }
    }

    // Private method to record an event for a goal
    private void RecordEvent()
    {   
        // Check if there are no goals
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
            return;
        }

        // Display the list of goals to choose from
        Console.WriteLine("Select the goal to record an event for:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStringRepresentation()}");
        }

         // Get the user's choice
        Console.Write("Enter the number of the goal: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        // Validate the choice and record the event
        if (index >= 0 && index < _goals.Count)
        {
            int pointsEarned = _goals[index].RecordEvent();
            _score += pointsEarned;
            Console.WriteLine($"Event recorded. You earned {pointsEarned} points.");
            Console.WriteLine($"Your new score is: {_score}");
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }


}
