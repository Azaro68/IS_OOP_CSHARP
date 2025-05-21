using Itmo.ObjectOrientedProgramming.Lab4.Visitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

public class DirectoryFileSystemComponent : IFileSystemComponent
{
    public DirectoryFileSystemComponent(
        string name,
        IReadOnlyCollection<IFileSystemComponent> components)
    {
        Name = name;
        Components = components;
    }

    public string Name { get; }

    public IReadOnlyCollection<IFileSystemComponent> Components { get; }

    public void Accept(IFileSystemComponentVisitor visitor)
    {
        visitor.Visit(this);
    }
}