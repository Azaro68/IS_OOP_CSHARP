using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeCommands;

public class TreeListDepthCommand : ICommand
{
    private readonly int _depth;

    public TreeListDepthCommand(int depth)
    {
        _depth = depth;
    }

    public ExecutionResult Execute(IContext context)
    {
        if (!context.FileSystem.Connection || _depth < 0)
        {
            return new ExecutionResult.Failure(new ParsingError());
        }

        context.FileSystem.ShowTree(_depth);
        return new ExecutionResult.Success();
    }
}