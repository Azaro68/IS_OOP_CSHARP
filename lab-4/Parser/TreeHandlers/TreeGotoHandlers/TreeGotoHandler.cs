using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.TreeHandlers.TreeGotoHandlers;

public class TreeGotoHandler : IHandler
{
    private const string _command = "goto";

    private readonly ICommandBuildingHandler<TreeGotoPathCommandBuilder> _nextInternalHandler;
    private IHandler? _nextExternalHandler;

    public TreeGotoHandler(ICommandBuildingHandler<TreeGotoPathCommandBuilder> handler)
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

        return _nextInternalHandler.Handle(command, new TreeGotoPathCommandBuilder());
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