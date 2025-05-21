using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Visitor;

public interface IFileSystemComponentVisitor
{
    void Visit(FileFileSystemComponent component);

    void Visit(DirectoryFileSystemComponent component);
}