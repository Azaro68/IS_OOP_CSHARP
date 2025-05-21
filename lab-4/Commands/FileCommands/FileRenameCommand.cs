using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;

public class FileRenameCommand : ICommand
{
    private readonly string? _path;
    private readonly string _name;

    public FileRenameCommand(string? path, string name)
    {
        _path = path;
        _name = name;
    }

    public ExecutionResult Execute(IContext context)
    {
        if (!context.FileSystem.Connection ||
            _path is null ||
            !context.FileSystem.ValidateFileExists(_path) ||
            string.IsNullOrEmpty(_name))
        {
            return new ExecutionResult.Failure(new ParsingError());
        }

        context.FileSystem.RenameFile(_path, _name);
        return new ExecutionResult.Success();
    }
}