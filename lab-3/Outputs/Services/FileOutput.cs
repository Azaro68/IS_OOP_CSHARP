using Itmo.ObjectOrientedProgramming.Lab3.Outputs.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Outputs.Services;

public class FileOutput : IOutput
{
    private readonly string _filePath;

    public FileOutput(string filePath)
    {
        _filePath = filePath;
    }

    public void Write(string color, string message)
    {
        using var writer = new StreamWriter(_filePath, append: true);
        writer.WriteLine($"Color: {color}\nMessage: {message}\n");
    }
}