using System;

public abstract class Activity
{
    private DateTime _date;
    private int _durationInMinutes;

    // Constructor to initialize date and duration
    public Activity(DateTime date, int durationInMinutes)
    {
        _date = date;
        _durationInMinutes = durationInMinutes;
    }

    // Properties to access date and duration
    public DateTime Date => _date;
    public int DurationInMinutes => _durationInMinutes;

    // Abstract methods to be implemented by derived classes
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    // Virtual method to provide a summary
    public virtual string GetSummary()
    {
        return $"{Date.ToString("dd MMM yyyy")} {this.GetType().Name} ({DurationInMinutes} min) - Distance: {GetDistance():0.0} miles, Speed: {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min per mile";
    }
}
