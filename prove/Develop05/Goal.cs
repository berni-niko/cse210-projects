// base class "goal"
public abstract class Goal
{
    // Properties for the goal's short name, description, and points
    public string ShortName { get; private set; }
    public string Description { get; private set; }
    public int Points { get; private set; }

    // Constructor to initialize the goal
    public Goal(string shortname, string description, int points)
    {
        ShortName = shortname;
        Description = description;
        Points = points;
    }

    // Abstract method to record an event
    public abstract int RecordEvent();

    // Abstract method to check if the goal is complete
    public abstract bool IsComplete();

    // Virtual method to get the details of the goal as a string
    public virtual string GetDetailsString()
    {
        return $"{ShortName}: {Description} worth {Points} points";
    }

    // Abstract method to get a string representation of the goal
    public abstract string GetStringRepresentation();
}