namespace Itmo.ObjectOrientedProgramming.Lab3.Messages.Models;

public record ReadableMessage
{
    public Message Message { get; }

    public bool IsRead { get; set; } = false;

    public ReadableMessage(Message message)
    {
        Message = message;
    }
}