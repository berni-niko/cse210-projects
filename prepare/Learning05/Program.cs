using System;
using System.Collections.Generic;
using System.Formats.Asn1;

public class Program
{
    public static void Main(string[] args)
    {
        //Create a list to hold shapes
        List<Shape> shapes = new List<Shape>();
        
        //Add square, rectanle, and circle list
        shapes.Add(new Square("Red", 5.0));
        shapes.Add(new Rectangle("Blue", 4.0, 6.0));
        shapes.Add(new Circle("Green", 3.0));

        //Iterate through the list of shapes
        foreach (Shape shape in shapes)
        {
            //call & display the GetColor() and GetArea methods
            Console.WriteLine("Shape Color: " + shape.Color);
            Console.WriteLine("Shape Area: " + Math.Round(shape.GetArea(), 2));
        }
    }
}
