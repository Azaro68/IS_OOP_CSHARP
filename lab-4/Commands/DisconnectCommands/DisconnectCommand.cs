using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.DisconnectCommands;

public class DisconnectCommand : ICommand
{
    public ExecutionResult Execute(IContext context)
    {
        context.FileSystem.DisconnectFileSystem();
        return new ExecutionResult.Success();
    }
}