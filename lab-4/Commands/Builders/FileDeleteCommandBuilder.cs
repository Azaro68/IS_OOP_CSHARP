using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

public class FileDeleteCommandBuilder
{
    private string? _path;

    public FileDeleteCommandBuilder WithPath(string path)
    {
        _path = path;
        return this;
    }

    public FileDeleteCommand Build() => new FileDeleteCommand(_path);
}