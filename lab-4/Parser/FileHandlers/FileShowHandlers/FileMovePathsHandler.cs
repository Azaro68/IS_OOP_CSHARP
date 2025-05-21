using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.FileHandlers.FileShowHandlers;

public class FileMovePathsHandler : ICommandBuildingHandler<FileMoveCommandBuilder>
{
    private ICommandBuildingHandler<FileMoveCommandBuilder>? nextInternalHandler;

    public ICommand Handle(IEnumerator<string> command, FileMoveCommandBuilder builder)
    {
        if (string.IsNullOrEmpty(command.Current))
        {
            return nextInternalHandler != null
                ? nextInternalHandler.Handle(command, new FileMoveCommandBuilder())
                : new NullCommand();
        }

        builder.WithSourcePath(command.Current);

        if (!command.MoveNext())
        {
            return new NullCommand();
        }

        if (string.IsNullOrEmpty(command.Current))
        {
            return nextInternalHandler != null
                ? nextInternalHandler.Handle(command, builder)
                : new NullCommand();
        }

        builder.WithDestinationPath(command.Current);

        return builder.Build();
    }

    public ICommandBuildingHandler<FileMoveCommandBuilder> SetNextHandler(
        ICommandBuildingHandler<FileMoveCommandBuilder> handler)
    {
        if (nextInternalHandler is null)
        {
            nextInternalHandler = handler;
            return this;
        }

        return nextInternalHandler.SetNextHandler(handler);
    }
}