public class Swimming : Activity
{
    private int _numberOfLaps;

    public Swimming(DateTime date, int durationInMinutes, int numberOfLaps) 
        : base(date, durationInMinutes)
    {
        _numberOfLaps = numberOfLaps;
    }

    public override double GetDistance()
    {
        return _numberOfLaps * 50 / 1000.0 * 0.62;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / DurationInMinutes) * 60;
    }

    public override double GetPace()
    {
        return DurationInMinutes / GetDistance();
    }
}