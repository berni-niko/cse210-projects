public class Circle : Shape
{
    // Constructor accepting color and radius
    public Circle(string color, double radius) : base(color)
    {
        // Initialize _radius
        _radius = radius;
    }
    
    //Create the _radius Attribute:
    private double _radius;

    // Override the GetArea method
    public override double GetArea()
    {
        return Math.PI * _radius * _radius;
    }

}