// class "simple goal"
public class SimpleGoal : Goal
{
    // Field to store the completion status of the goal
    private bool _isComplete;

    // Constructor to initialize the simple goal
    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }

    // Override method to record an event and mark the goal as complete
    public override int RecordEvent()
    {
        _isComplete = true;
        return Points;
    }

    // Override method to check if the goal is complete
    public override bool IsComplete()
    {
        return _isComplete;
    }

    // Override method to get the string representation of the simple goal
    public override string GetStringRepresentation()
    {
        return $"[{(_isComplete ? 'x' : ' ')}] {ShortName}: {Description} - {Points} points";
    }
}