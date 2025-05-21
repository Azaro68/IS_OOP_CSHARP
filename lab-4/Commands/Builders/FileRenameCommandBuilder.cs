using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

public class FileRenameCommandBuilder
{
    private string? _path;
    private string? _name;

    public FileRenameCommandBuilder WithPath(string path)
    {
        _path = path;
        return this;
    }

    public FileRenameCommandBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ICommand Build() => new FileRenameCommand(
        path: _path,
        name: _name ?? throw new InvalidOperationException());
}