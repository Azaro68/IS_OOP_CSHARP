using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

public class TreeListDepthCommandBuilder
{
    private int _depth;

    public TreeListDepthCommandBuilder WithDepth(int depth)
    {
        _depth = depth;
        return this;
    }

    public ICommand Build() => new TreeListDepthCommand(_depth);
}