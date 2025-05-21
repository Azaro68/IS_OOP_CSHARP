using Itmo.ObjectOrientedProgramming.Lab4.Visitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

public interface IFileSystemComponent
{
    string Name { get; }

    void Accept(IFileSystemComponentVisitor visitor);
}