using Itmo.ObjectOrientedProgramming.Lab3.Outputs.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays.Models;

public class DisplayDriver
{
    private readonly IOutput _output;

    public string? Color { get; set; }

    public DisplayDriver(IOutput output)
    {
        _output = output;
    }

    public void Clear()
    {
        _output.Write(Color ?? "Default", string.Empty);
    }

    public void PrintMessage(string message)
    {
        Clear();
        _output.Write(Color ?? "Default", message);
    }
}