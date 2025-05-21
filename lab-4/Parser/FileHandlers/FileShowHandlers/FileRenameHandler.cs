using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;
using ICommand = Itmo.ObjectOrientedProgramming.Lab4.Commands.ICommand;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.FileHandlers.FileShowHandlers;

public class FileRenameHandler : IHandler
{
    private const string _command = "rename";

    private readonly ICommandBuildingHandler<FileRenameCommandBuilder> _nextInternalHandler;
    private IHandler? _nextExternalHandler;

    public FileRenameHandler(ICommandBuildingHandler<FileRenameCommandBuilder> handler)
    {
        _nextInternalHandler = handler;
    }

    public ICommand Handle(IEnumerator<string> command)
    {
        if (command.Current is not _command)
        {
            return _nextExternalHandler != null
                ? _nextExternalHandler.Handle(command)
                : new NullCommand();
        }

        if (!command.MoveNext())
        {
            return new NullCommand();
        }

        return _nextInternalHandler.Handle(command, new FileRenameCommandBuilder());
    }

    public IHandler SetNextExternalHandler(IHandler? handler)
    {
        if (_nextExternalHandler is null)
        {
            _nextExternalHandler = handler;
            return this;
        }

        return _nextExternalHandler.SetNextExternalHandler(handler);
    }
}