using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.ConnectHandlers;

public class ConnectAddressHandler : ICommandBuildingHandler<ConnectAddressCommandBuilder>
{
    private readonly ICommandBuildingHandler<ConnectAddressCommandBuilder> _nextInternalHandler;

    public ConnectAddressHandler(
        ICommandBuildingHandler<ConnectAddressCommandBuilder> handler)
    {
        _nextInternalHandler = handler;
    }

    public ICommand Handle(
        IEnumerator<string> command,
        ConnectAddressCommandBuilder builder)
    {
        if (string.IsNullOrEmpty(command.Current))
        {
            return _nextInternalHandler != null
                ? _nextInternalHandler.Handle(command, new ConnectAddressCommandBuilder())
                : new NullCommand();
        }

        builder.WithPath(command.Current);

        if (!command.MoveNext())
        {
            return new NullCommand();
        }

        return _nextInternalHandler.Handle(command, builder);
    }

    public ICommandBuildingHandler<ConnectAddressCommandBuilder> SetNextHandler(
        ICommandBuildingHandler<ConnectAddressCommandBuilder> handler)
    {
        return _nextInternalHandler.SetNextHandler(handler);
    }
}