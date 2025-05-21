using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.ConnectHandlers;

public class ConnectAddressModeHandler : ICommandBuildingHandler<ConnectAddressCommandBuilder>
{
    private ICommandBuildingHandler<ConnectAddressCommandBuilder> _nextInternalHandler;

    public ConnectAddressModeHandler(
        ICommandBuildingHandler<ConnectAddressCommandBuilder> handler)
    {
        _nextInternalHandler = handler;
    }

    public ICommand Handle(
        IEnumerator<string> command,
        ConnectAddressCommandBuilder builder)
    {
        if (command.Current != "-m")
        {
            return _nextInternalHandler != null
                ? _nextInternalHandler.Handle(command, builder)
                : new NullCommand();
        }

        if (!command.MoveNext())
        {
            return new NullCommand();
        }

        return _nextInternalHandler.Handle(command, builder);
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