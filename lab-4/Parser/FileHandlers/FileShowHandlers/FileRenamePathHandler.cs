using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.FileHandlers.FileShowHandlers;

public class FileRenamePathHandler : ICommandBuildingHandler<FileRenameCommandBuilder>
{
    private ICommandBuildingHandler<FileRenameCommandBuilder>? _nextInternalHandler;

    public ICommand Handle(IEnumerator<string> command, FileRenameCommandBuilder builder)
    {
        if (string.IsNullOrEmpty(command.Current))
        {
            return _nextInternalHandler != null
                ? _nextInternalHandler.Handle(command, new FileRenameCommandBuilder())
                : new NullCommand();
        }

        builder.WithPath(command.Current);

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

        builder.WithName(command.Current);

        return builder.Build();
    }

    public ICommandBuildingHandler<FileRenameCommandBuilder> SetNextHandler(
        ICommandBuildingHandler<FileRenameCommandBuilder> handler)
    {
        if (_nextInternalHandler is null)
        {
            _nextInternalHandler = handler;
            return this;
        }

        return _nextInternalHandler.SetNextHandler(handler);
    }
}