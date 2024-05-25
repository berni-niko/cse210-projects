// Class "checklist goal"
public class ChecklistGoal : Goal
{
    // Properties to store the number of times the event has been completed, the target amount, and the bonus points
    public int AmountCompleted { get; private set; }
    public int Target { get; private set; }
    public int Bonus { get; private set; }

    // Constructor to initialize the checklist goal
    public ChecklistGoal(string shortname, string description, int points, int target, int bonus) : base(shortname, description, points)
    {
        AmountCompleted = 0;
        Target = target;
        Bonus = bonus;
    }

    // Override method to record an event and check if the target has been reached
    public override int RecordEvent()
    {
        AmountCompleted++;

        // Check if the target amount has been completed
        if (AmountCompleted >= Target)
        {
            return Points + Bonus;
        }

        return Points;
    }

    // Override method to check if the goal is complete
    public override bool IsComplete()
    {
        return AmountCompleted >= Target;
    }

    // Override method to get the details of the checklist goal
    public override string GetDetailsString()
    {
        return $"{ShortName}: {Description} - {Points} points (Completed {AmountCompleted}/{Target} times, Bonus: {Bonus} points)";
    }

    // Override method to get the string representation of the checklist goal
    public override string GetStringRepresentation()
    {
        return $"{ShortName}: {Description} - {Points} points (Completed {AmountCompleted}/{Target} times)";
    }
}