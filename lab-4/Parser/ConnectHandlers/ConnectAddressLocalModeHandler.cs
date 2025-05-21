using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.ConnectHandlers;

public class ConnectAddressLocalModeHandler : ICommandBuildingHandler<ConnectAddressCommandBuilder>
{
    private const string _command = "local";

    private ICommandBuildingHandler<ConnectAddressCommandBuilder>? _nextInternalHandler;

    public ICommand Handle(
        IEnumerator<string> command,
        ConnectAddressCommandBuilder builder)
    {
        if (command.Current is not _command)
        {
            return _nextInternalHandler != null
                ? _nextInternalHandler.Handle(command, builder)
                : new NullCommand();
        }

        if (string.IsNullOrEmpty(command.Current))
        {
            return new NullCommand();
        }

        return builder.Build();
    }

    public ICommandBuildingHandler<ConnectAddressCommandBuilder> SetNextHandler(
        ICommandBuildingHandler<ConnectAddressCommandBuilder> handler)
    {
        if (_nextInternalHandler is null)
        {
            _nextInternalHandler = handler;
            return this;
        }

        return _nextInternalHandler.SetNextHandler(handler);
    }
}