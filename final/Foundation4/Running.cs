public class Running : Activity
{
    private double _distance;
    
    public Running(DateTime date, int durationInMinutes, double distance) 
        : base(date, durationInMinutes)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return (_distance / DurationInMinutes) * 60;
    }

    public override double GetPace()
    {
        return DurationInMinutes / _distance;
    }
}

