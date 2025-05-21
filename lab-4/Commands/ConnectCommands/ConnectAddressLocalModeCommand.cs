using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.ConnectCommands;

public class ConnectAddressLocalModeCommand : ICommand
{
    private readonly string? _address;

    public ConnectAddressLocalModeCommand(string? address)
    {
        _address = address;
    }

    public ExecutionResult Execute(IContext context)
    {
        context.FileSystem.ConnectFileSystem(_address);
        return new ExecutionResult.Success();
    }
}