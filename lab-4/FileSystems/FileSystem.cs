using Itmo.ObjectOrientedProgramming.Lab4.Visitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

public class FileSystem : IFileSystem
{
    public bool Connection { get; private set; }

    public string? Paths { get; private set; }

    public void ConnectFileSystem(string? path)
    {
        Paths = path;
        Connection = true;
    }

    public void MoveFile(string? from, string destination)
    {
        from = CheckPath(from);
        destination = CheckPath(destination);
        File.Move(from, destination);
    }

    public void CopyFile(string? from, string destination)
    {
        from = CheckPath(from);
        destination = CheckPath(destination);
        File.Copy(from, destination);
    }

    public void DeleteFile(string? path)
    {
        path = CheckPath(path);
        File.Delete(path);
    }

    public void ShowFile(string? path)
    {
        path = CheckPath(path);
        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(path) { UseShellExecute = true });
    }

    public void ShowTree(int depth)
    {
        var factory = new FileSystemComponentFactory();
        if (Paths != null)
        {
            IFileSystemComponent root = factory.Create(Paths);

            var consoleOutput = new ConsoleOutputer();
            var visitor = new ConsoleVisitor(consoleOutput);

            root.Accept(visitor);
        }
    }

    public void RenameFile(string? path, string name)
    {
        path = CheckPath(path);
        string newFilePath = Path.Combine(Path.GetDirectoryName(path) ?? throw new InvalidOperationException(), name);
        File.Move(path, newFilePath);
    }

    public void ChangePath(string? path)
    {
        Paths = CheckPath(path);
    }

    public void DisconnectFileSystem()
    {
        Connection = false;
    }

    public bool ValidateFileExists(string? path)
    {
        path = CheckPath(path);
        return File.Exists(path);
    }

    public bool ValidateDirectoryExists(string? path)
    {
        path = CheckPath(path);
        return Directory.Exists(path);
    }

    private string CheckPath(string? path)
    {
        if (path is null || !Path.IsPathRooted(path) || !path.StartsWith("/Users"))
        {
            path = Paths + path;
        }

        return path;
    }
}