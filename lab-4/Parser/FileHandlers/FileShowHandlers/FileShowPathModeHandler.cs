using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.FileHandlers.FileShowHandlers;

public class FileShowPathModeHandler : ICommandBuildingHandler<FileShowConsoleCommandBuilder>
{
    private ICommandBuildingHandler<FileShowConsoleCommandBuilder>? _nextInternalHandler;

    public ICommand Handle(IEnumerator<string> command, FileShowConsoleCommandBuilder builder)
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

        if (command.Current != "console")
        {
            return _nextInternalHandler != null
                ? _nextInternalHandler.Handle(command, builder)
                : new NullCommand();
        }

        return builder.Build();
    }

    public ICommandBuildingHandler<FileShowConsoleCommandBuilder> SetNextHandler(
        ICommandBuildingHandler<FileShowConsoleCommandBuilder> handler)
    {
        if (_nextInternalHandler is null)
        {
            _nextInternalHandler = handler;
            return this;
        }

        return _nextInternalHandler.SetNextHandler(handler);
    }
}