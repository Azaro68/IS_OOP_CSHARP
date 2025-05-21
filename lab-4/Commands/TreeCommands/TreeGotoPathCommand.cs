using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeCommands;

public class TreeGotoPathCommand : ICommand
{
    private readonly string? _path;

    public TreeGotoPathCommand(string? path)
    {
        _path = path;
    }

    public ExecutionResult Execute(IContext context)
    {
        if (!context.FileSystem.Connection ||
            _path is null || !context.FileSystem.ValidateFileExists(_path))
        {
            return new ExecutionResult.Failure(new ParsingError());
        }

        context.FileSystem.ChangePath(_path);
        return new ExecutionResult.Success();
    }
}