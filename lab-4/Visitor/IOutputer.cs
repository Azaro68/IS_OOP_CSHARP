namespace Itmo.ObjectOrientedProgramming.Lab4.Visitor;

public interface IOutputer
{
    void Write(string value);

    void WriteLine(string value);
}