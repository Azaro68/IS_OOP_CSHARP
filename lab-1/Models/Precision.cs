namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class Precision
{
    public int Value { get; }

    public Precision(int value)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), value, "The value must be greater than or equal to zero.");
        }

        Value = value;
    }
}