using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Contexts;

public interface IContext
{
    string? Paths { get; }

    IFileSystem FileSystem { get; }

    public void ChangePath(string? path);
}