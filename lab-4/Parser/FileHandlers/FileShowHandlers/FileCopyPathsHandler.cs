using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.FileHandlers.FileShowHandlers;

public class FileCopyPathsHandler : ICommandBuildingHandler<FileCopyCommandBuilder>
{
    private ICommandBuildingHandler<FileCopyCommandBuilder>? _nextInternalHandler;

    public ICommand Handle(IEnumerator<string> command, FileCopyCommandBuilder builder)
    {
        if (string.IsNullOrEmpty(command.Current))
        {
            return _nextInternalHandler != null
                ? _nextInternalHandler.Handle(command, new FileCopyCommandBuilder())
                : new NullCommand();
        }

        builder.WithSourcePath(command.Current);

        if (!command.MoveNext())
        {
            return new NullCommand();
        }

        if (string.IsNullOrEmpty(command.Current))
        {
            return _nextInternalHandler != null
                ? _nextInternalHandler.Handle(command, builder)
                : new NullCommand();
        }

        builder.WithDestinationPath(command.Current);

        return builder.Build();
    }

    public ICommandBuildingHandler<FileCopyCommandBuilder> SetNextHandler(
        ICommandBuildingHandler<FileCopyCommandBuilder> handler)
    {
        if (_nextInternalHandler is null)
        {
            _nextInternalHandler = handler;
            return this;
        }

        return _nextInternalHandler.SetNextHandler(handler);
    }
}