using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

public class TreeGotoPathCommandBuilder
{
    private string? _path;

    public TreeGotoPathCommandBuilder WithPath(string? path)
    {
        _path = path;
        return this;
    }

    public TreeGotoPathCommand Build() => new TreeGotoPathCommand(_path);
}