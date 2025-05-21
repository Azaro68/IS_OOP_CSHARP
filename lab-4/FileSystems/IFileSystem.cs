namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

public interface IFileSystem
{
    bool Connection { get; }

    void MoveFile(string? from, string destination);

    void CopyFile(string? from, string destination);

    void DeleteFile(string? path);

    void ShowFile(string? path);

    void ShowTree(int depth);

    void RenameFile(string? path, string name);

    void ConnectFileSystem(string? path);

    void ChangePath(string? path);

    void DisconnectFileSystem();

    bool ValidateFileExists(string path);

    bool ValidateDirectoryExists(string path);
}