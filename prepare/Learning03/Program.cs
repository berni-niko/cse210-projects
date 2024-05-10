using System;

class Program
{
    static void Main(string[] args)
    {
        // Test Fraction class

        // Instance: f1 (using default constructor)
        Fraction f1 = new Fraction();
        // Method: GetFractionString
        Console.WriteLine(f1.GetFractionString()); // Output: 1/1
        // Method: GetDecimalValue
        Console.WriteLine(f1.GetDecimalValue());   // Output: 1.0

        // Instance: f2 (using constructor with one parameter)
        Fraction f2 = new Fraction(5);
        // Method: GetFractionString
        Console.WriteLine(f2.GetFractionString()); // Output: 5/1
        // Method: GetDecimalValue
        Console.WriteLine(f2.GetDecimalValue());   // Output: 5.0

        // Instance: f3 (using constructor with two parameters)
        Fraction f3 = new Fraction(3, 4);
        // Method: GetFractionString
        Console.WriteLine(f3.GetFractionString()); // Output: 3/4
        // Method: GetDecimalValue
        Console.WriteLine(f3.GetDecimalValue());   // Output: 0.75

        // Instance: f4 (using constructor with two parameters)
        Fraction f4 = new Fraction(1, 3);
        // Method: GetFractionString
        Console.WriteLine(f4.GetFractionString()); // Output: 1/3
        // Method: GetDecimalValue
        Console.WriteLine(f4.GetDecimalValue());   // Output: 0.3333333333
    }
}

class Fraction
{
    // Private fields (represent the object’s state)
    private int _numerator;
    private int _denominator;
    
    // Constructor (default)
    public Fraction()
    {
        _numerator = 1;
        _denominator = 1;
    }

    // Constructor (with one parameter)
    public Fraction(int numerator)
    {
        _numerator = numerator;
        _denominator = 1;
    }

    // Constructor (with two parameters)
    public Fraction(int numerator, int denominator)
    {
        _numerator = numerator;
        _denominator = denominator;
    }

    // Method: get_numerator
    public int get_numerator()
    {
        return _numerator;
    }

    // Method: set_numerator
    public void set_numerator(int numerator)
    {
        _numerator = numerator;
    }

    // Method: get_denominator
    public int get_denominator()
    {
        return _denominator;
    }

    // Method: set_denominator
    public void set_denominator(int denominator)
    {
        _denominator = denominator;
    }

    // Method: GetFractionString
    public string GetFractionString()
    {
        return $"{_numerator}/{_denominator}";
    }

    // Method: GetDecimalValue
    public double GetDecimalValue()
    {
        return (double)_numerator / _denominator;
        
    }
}
