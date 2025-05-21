using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using ICommand = Itmo.ObjectOrientedProgramming.Lab4.Commands.ICommand;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.TreeHandlers;

public class TreeHandler : IHandler
{
    private const string _command = "tree";

    private readonly IHandler _nextInternalHandler;
    private IHandler? _nextExternalHandler;

    public TreeHandler(IHandler handler)
    {
        _nextInternalHandler = handler;
    }

    public ICommand Handle(IEnumerator<string> command)
    {
        if (command.Current is not _command)
        {
            if (_nextExternalHandler != null)
            {
                return _nextExternalHandler.Handle(command);
            }

            return new NullCommand();
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