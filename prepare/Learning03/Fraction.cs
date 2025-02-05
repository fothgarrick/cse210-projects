using System;

public class Fraction
{
    // Private attributes with underscore convention for numerator and denominator
    private int _top;
    private int _bottom;

    // Constructor with no parameters, sets fraction to 1/1
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // Constructor with one parameter (for numerator), denominator is set to 1
    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }

    // Constructor with two parameters (numerator and denominator)
    public Fraction(int top, int bottom)
    {
        _top = top;
        if (bottom != 0) // Ensure denominator isn't zero
        {
            _bottom = bottom;
        }
        else
        {
            Console.WriteLine("Denominator cannot be zero!");
            _bottom = 1; // Default to 1 to avoid invalid state
        }
    }

    // Getter and setter for numerator (_top)
    public int GetTop()
    {
        return _top;
    }

    public void SetTop(int top)
    {
        _top = top;
    }

    // Getter and setter for denominator (_bottom)
    public int GetBottom()
    {
        return _bottom;
    }

    public void SetBottom(int bottom)
    {
        if (bottom != 0)
        {
            _bottom = bottom;
        }
        else
        {
            Console.WriteLine("Denominator cannot be zero!");
        }
    }

    // Method to return the fraction as a string (fractional form)
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    // Method to return the decimal value of the fraction
    public double GetDecimalValue()
    {
        return (double)_top / (double)_bottom;
    }
}
