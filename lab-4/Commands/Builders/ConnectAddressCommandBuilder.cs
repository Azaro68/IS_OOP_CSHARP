using Itmo.ObjectOrientedProgramming.Lab4.Commands.ConnectCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

public class ConnectAddressCommandBuilder
{
    private string? _path;

    public ConnectAddressCommandBuilder WithPath(string path)
    {
        _path = path;
        return this;
    }

    public ICommand Build() => new ConnectAddressLocalModeCommand(_path);
}