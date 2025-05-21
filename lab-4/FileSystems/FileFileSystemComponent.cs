using Itmo.ObjectOrientedProgramming.Lab4.Visitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

public class FileFileSystemComponent : IFileSystemComponent
{
    public FileFileSystemComponent(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public void Accept(IFileSystemComponentVisitor visitor)
    {
        visitor.Visit(this);
    }
}