using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public sealed class NullCommand : ICommand
{
    public ExecutionResult Execute(IContext context)
    {
        return new ExecutionResult.Failure(new ParsingError());
    }
}