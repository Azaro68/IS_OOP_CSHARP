using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.DisconnectCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.DisconnectHandlers;

public class DisconnectHandler : IHandler
{
    private const string _command = "disconnect";

    private IHandler? _nextExternalHandler;

    public ICommand Handle(IEnumerator<string> command)
    {
        if (command.Current is not _command)
        {
            return _nextExternalHandler != null
                ? _nextExternalHandler.Handle(command)
                : new NullCommand();
        }

        return new DisconnectCommand();
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