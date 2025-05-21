using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;

public class FileMoveCommand : ICommand
{
    private readonly string? _sourcePath;
    private readonly string _destinationPath;

    public FileMoveCommand(string? sourcePath, string destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public ExecutionResult Execute(IContext context)
    {
        if (!context.FileSystem.Connection ||
            _sourcePath is null ||
            !context.FileSystem.ValidateFileExists(_sourcePath) ||
            !context.FileSystem.ValidateFileExists(_destinationPath))
        {
            return new ExecutionResult.Failure(new ParsingError());
        }

        context.FileSystem.MoveFile(_sourcePath, _destinationPath);
        return new ExecutionResult.Failure(new ParsingError());
    }
}