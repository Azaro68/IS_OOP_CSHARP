using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.FileHandlers.FileShowHandlers;

public class FileDeletePathHandler : ICommandBuildingHandler<FileDeleteCommandBuilder>
{
    private ICommandBuildingHandler<FileDeleteCommandBuilder>? _nextInternalHandler;

    public ICommand Handle(IEnumerator<string> command, FileDeleteCommandBuilder builder)
    {
        if (string.IsNullOrEmpty(command.Current))
        {
            return _nextInternalHandler != null
                ? _nextInternalHandler.Handle(command, new FileDeleteCommandBuilder())
                : new NullCommand();
        }

        builder.WithPath(command.Current);
        return builder.Build();
    }

    public ICommandBuildingHandler<FileDeleteCommandBuilder> SetNextHandler(
        ICommandBuildingHandler<FileDeleteCommandBuilder> handler)
    {
        if (_nextInternalHandler is null)
        {
            _nextInternalHandler = handler;
            return this;
        }

        return _nextInternalHandler.SetNextHandler(handler);
    }
}