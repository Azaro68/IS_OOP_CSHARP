using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders;

public class FileCopyCommandBuilder
{
    private string? _sourcePath;
    private string? _destinationPath;

    public FileCopyCommandBuilder WithSourcePath(string sourcePath)
    {
        _sourcePath = sourcePath;
        return this;
    }

    public FileCopyCommandBuilder WithDestinationPath(string destinationPath)
    {
        _destinationPath = destinationPath;
        return this;
    }

    public FileCopyCommand Build() => new FileCopyCommand(
        _sourcePath,
        _destinationPath ?? throw new InvalidOperationException());
}