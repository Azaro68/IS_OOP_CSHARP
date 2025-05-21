using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

public class FileMoveCommandBuilder
{
    private string? _sourcePath;
    private string? _destinationPath;

    public FileMoveCommandBuilder WithSourcePath(string sourcePath)
    {
        _sourcePath = sourcePath;
        return this;
    }

    public FileMoveCommandBuilder WithDestinationPath(string destinationPath)
    {
        _destinationPath = destinationPath;
        return this;
    }

    public ICommand Build() => new FileMoveCommand(
        _sourcePath,
        _destinationPath ?? throw new InvalidOperationException());
}