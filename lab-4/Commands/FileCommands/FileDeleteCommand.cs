using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;

public class FileDeleteCommand : ICommand
{
    private readonly string? _path;

    public FileDeleteCommand(string? path)
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

        context.FileSystem.DeleteFile(_path);
        return new ExecutionResult.Success();
    }
}