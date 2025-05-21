using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Contexts;

public class Context : IContext
{
    public Context(IFileSystem fileSystem)
    {
        FileSystem = fileSystem;
    }

    public string? Paths { get; private set; }

    public IFileSystem FileSystem { get; }

    public void ChangePath(string? path)
    {
        Paths = path;
    }
}