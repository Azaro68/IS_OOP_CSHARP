using Crayon;
using IOutput = Itmo.ObjectOrientedProgramming.Lab3.Outputs.Interfaces.IOutput;

namespace Itmo.ObjectOrientedProgramming.Lab3.Outputs.Services;

public class ConsoleOutput : IOutput
{
    public void Write(string color, string message)
    {
        string coloredMessage = color.ToLowerInvariant() switch
        {
            "red" => Output.Red(message),
            "green" => Output.Green(message),
            "blue" => Output.Blue(message),
            "yellow" => Output.Yellow(message),
            "magenta" => Output.Magenta(message),
            "cyan" => Output.Cyan(message),
            _ => message,
        };

        Console.WriteLine(coloredMessage);
    }
}