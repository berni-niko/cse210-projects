public class Rectangle : Shape
{
    // Constructor accepting color, length, and width
    public Rectangle(string color, double length, double width) : base(color)
    {
        // Initialize _length and _width
        _length = length;
        _width = width;
    }
    
    // Create the _length and _width Attributes:
    private double _length;
    private double _width;

    // Override the GetArea method
    public override double GetArea()
    {
        return _length * _width;
    }

}