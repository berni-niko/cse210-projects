// class "eternal goal"
public class EternalGoal : Goal
{
    // Field to store the number of times the event has been recorded
    protected int _recordCount;

    // Constructor to initialize the eternal goal
    public EternalGoal(string shortname, string description, int points) : base(shortname, description, points)
    {
        _recordCount = 0;
    }

    // Override method to record an event and increase the record count
    public override int RecordEvent()
    {
        _recordCount++;
        return Points;
    }

    // Override method to always return false as eternal goals never complete
    public override bool IsComplete()
    {
        return false;
    }

    // Override method to get the string representation of the eternal goal
    public override string GetStringRepresentation()
    {
        return $"[ ] {ShortName}: {Description} - {Points} points (Recorded {_recordCount} times)";
    }
}