namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class Mass
{
    public double Value { get; private set; }

    public Mass(double value)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), value, "The value must be greater than or equal to zero.");
        }

        Value = value;
    }
}