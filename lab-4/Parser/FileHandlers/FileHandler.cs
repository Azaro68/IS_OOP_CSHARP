using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.FileHandlers;

public class FileHandler : IHandler
{
    private readonly IHandler _nextInternalHandler;
    private IHandler? _nextExternalHandler;

    public FileHandler(IHandler handler)
    {
        _nextInternalHandler = handler;
    }

    public ICommand Handle(IEnumerator<string> command)
    {
        if (command.Current != "file")
        {
            return _nextExternalHandler != null
                ? _nextExternalHandler.Handle(command)
                : new NullCommand();
        }

        if (!command.MoveNext())
        {
            return new NullCommand();
        }

        return _nextInternalHandler.Handle(command);
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