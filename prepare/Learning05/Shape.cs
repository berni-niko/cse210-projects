using System.Security;

public class Shape
{

    private string _color;

// Public property for accessing and setting color
    public string Color
    {
        get { return _color; }
        set { _color = value; }
    }

    // Constructor that accepts color as parameter
    public Shape(string color)
    {
        _color = color;
    }
    // Virtual method for getting area, to be overridden by derived classes
    public virtual double GetArea()
    {
        return 0.0;
    }
}