namespace Itmo.ObjectOrientedProgramming.Lab4.Visitor;

public class ConsoleOutputer : IOutputer
{
    public void Write(string value)
    {
        Console.Write(value);
    }

    public void WriteLine(string value)
    {
        Console.WriteLine(value);
    }
}