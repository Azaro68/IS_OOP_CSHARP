using Itmo.ObjectOrientedProgramming.Lab3.ImportanceLevels;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages.Models;

public record Message
{
    public string Title { get; }

    public string Body { get; }

    public ImportanceLevel Importancy { get; }

    public Message(
        string title,
        string body,
        ImportanceLevel importancy)
    {
        Title = title;
        Body = body;
        Importancy = importancy;
    }
}