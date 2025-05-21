using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.FileHandlers.FileShowHandlers;

public class FileShowPathHandler : ICommandBuildingHandler<FileShowConsoleCommandBuilder>
{
    private readonly ICommandBuildingHandler<FileShowConsoleCommandBuilder> _nextInternalHandler;

    public FileShowPathHandler(ICommandBuildingHandler<FileShowConsoleCommandBuilder> handler)
    {
        _nextInternalHandler = handler;
    }

    public ICommand Handle(IEnumerator<string> command, FileShowConsoleCommandBuilder builder)
    {
        if (string.IsNullOrEmpty(command.Current))
        {
            return new NullCommand();
        }

        builder.WithPath(command.Current);
        if (!command.MoveNext())
        {
            return new NullCommand();
        }

        return _nextInternalHandler.Handle(command, builder);
    }

    public ICommandBuildingHandler<FileShowConsoleCommandBuilder> SetNextHandler(
        ICommandBuildingHandler<FileShowConsoleCommandBuilder> handler)
    {
        return _nextInternalHandler.SetNextHandler(handler);
    }
}