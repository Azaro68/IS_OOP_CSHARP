using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.TreeHandlers.TreeListHandlers;

public class TreeListDepthHandler : ICommandBuildingHandler<TreeListDepthCommandBuilder>
{
    private ICommandBuildingHandler<TreeListDepthCommandBuilder>? nextInternalHandler;

    public ICommand Handle(IEnumerator<string> command, TreeListDepthCommandBuilder builder)
    {
        if (command.Current != "-d")
        {
            return nextInternalHandler != null
                ? nextInternalHandler.Handle(command, new TreeListDepthCommandBuilder())
                : new NullCommand();
        }

        if (!command.MoveNext() || string.IsNullOrEmpty(command.Current))
        {
            return new NullCommand();
        }

        builder.WithDepth(int.Parse(command.Current));
        return builder.Build();
    }

    public ICommandBuildingHandler<TreeListDepthCommandBuilder> SetNextHandler(ICommandBuildingHandler<TreeListDepthCommandBuilder> handler)
    {
        if (nextInternalHandler is null)
        {
            nextInternalHandler = handler;
            return this;
        }

        return nextInternalHandler.SetNextHandler(handler);
    }
}