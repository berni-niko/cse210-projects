public class Cycling : Activity
{
    private double _speed;

    // Constructor to initialize speed along with base class properties
    public Cycling(DateTime date, int durationInMinutes, double speed) 
        : base(date, durationInMinutes)
    {
        _speed = speed;
    }

    // Override methods to provide specific implementations for cycling
    public override double GetDistance()
    {
        return (_speed * DurationInMinutes) / 60;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return 60 / _speed;
    }
}
