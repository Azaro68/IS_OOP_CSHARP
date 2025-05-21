using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

public class FileShowConsoleCommandBuilder
{
    private string? _path;

    public FileShowConsoleCommandBuilder WithPath(string? path)
    {
        _path = path;
        return this;
    }

    public FileShowConsoleCommand Build() => new FileShowConsoleCommand(_path);
}