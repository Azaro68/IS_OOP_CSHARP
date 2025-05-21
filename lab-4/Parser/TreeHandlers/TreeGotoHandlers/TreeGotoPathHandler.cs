using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.TreeHandlers.TreeGotoHandlers;

public class TreeGotoPathHandler : ICommandBuildingHandler<TreeGotoPathCommandBuilder>
{
    private ICommandBuildingHandler<TreeGotoPathCommandBuilder>? nextInternalHandler;

    public ICommand Handle(IEnumerator<string> command, TreeGotoPathCommandBuilder builder)
    {
        if (string.IsNullOrEmpty(command.Current))
        {
            return nextInternalHandler != null
                ? nextInternalHandler.Handle(command, new TreeGotoPathCommandBuilder())
                : new NullCommand();
        }

        builder.WithPath(command.Current);
        return builder.Build();
    }

    public ICommandBuildingHandler<TreeGotoPathCommandBuilder> SetNextHandler(ICommandBuildingHandler<TreeGotoPathCommandBuilder> handler)
    {
        if (nextInternalHandler is null)
        {
            nextInternalHandler = handler;
            return this;
        }

        return nextInternalHandler.SetNextHandler(handler);
    }
}