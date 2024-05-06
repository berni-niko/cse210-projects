using System;

class Program
{
    static void Main(string[] args)
    {
        // Test Fraction class

        // Test 1: 1/1
        Fraction f1 = new Fraction();
        Console.WriteLine(f1.GetFractionString()); // Output: 1/1
        Console.WriteLine(f1.GetDecimalValue());   // Output: 1.0

        // Test 2: 6/1
        Fraction f2 = new Fraction(5);
        Console.WriteLine(f2.GetFractionString()); // Output: 5/1
        Console.WriteLine(f2.GetDecimalValue());   // Output: 5.0

        // Test 3: 3/4
        Fraction f3 = new Fraction(3, 4);
        Console.WriteLine(f3.GetFractionString()); // Output: 3/4
        Console.WriteLine(f3.GetDecimalValue());   // Output: 0.75

        // Test 4: 1/3
        Fraction f4 = new Fraction(1, 3);
        Console.WriteLine(f4.GetFractionString()); // Output: 1/3
        Console.WriteLine(f4.GetDecimalValue());   // Output: 0.3333333333

    }
}

class Fraction
{
    private int _numerator;
    private int _denominator;
    
    public Fraction()
    {
        _numerator = 1;
        _denominator = 1;
    }
    public Fraction(int numerator)
    {
        _numerator = numerator;
        _denominator = 1;
    }
    public Fraction(int numerator, int denominator)
    {
        _numerator = numerator;
        _denominator = denominator;
    }
    public int get_numerator()
    {
        return _numerator;

    }
        public void set_numerator(int numerator)
    {
        _numerator = numerator;
    }

    public int get_denominator()
    {
        return _denominator;
    }

    public void set_denominator(int denominator)
    {
        _denominator = denominator;
    }

    public string GetFractionString()
    {
        return $"{_numerator}/{_denominator}";
    }

        public double GetDecimalValue()
    {
        return (double)_numerator / _denominator;
    }
}


