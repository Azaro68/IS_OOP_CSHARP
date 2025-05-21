namespace Itmo.ObjectOrientedProgramming.Lab3.Displays.Models;

public class Display
{
    private readonly DisplayDriver _displayDriver;

    public Display(DisplayDriver displayDriver)
    {
        _displayDriver = displayDriver;
    }

    public void RecieveMessage(string message)
    {
        _displayDriver.PrintMessage(message);
    }

    public void ChangeColor(string color)
    {
        _displayDriver.Color = color;
    }
}