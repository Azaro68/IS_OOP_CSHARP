using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Visitor;

public class ConsoleVisitor : IFileSystemComponentVisitor
{
    private readonly Outputer _formatter;
    private int _depth;

    public ConsoleVisitor(IOutputer output, string horizontalSpace = "   ", string connector = "|-->")
    {
        _formatter = new Outputer(output, horizontalSpace, connector);
    }

    public void Visit(FileFileSystemComponent component)
    {
        _formatter.WriteIndented(component.Name, _depth);
    }

    public void Visit(DirectoryFileSystemComponent component)
    {
        _formatter.WriteIndented(component.Name, _depth);

        _depth += 1;

        foreach (IFileSystemComponent innerComponent in component.Components)
        {
            innerComponent.Accept(this);
        }

        _depth -= 1;
    }
}