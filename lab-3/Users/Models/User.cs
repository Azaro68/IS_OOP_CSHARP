using Itmo.ObjectOrientedProgramming.Lab3.Errors.Services;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Models;
using Itmo.ObjectOrientedProgramming.Lab3.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users.Models;

public class User
{
    public string Name { get; }

    public int Age { get; }

    public IReadOnlyCollection<ReadableMessage> Messages { get; }

    private readonly List<ReadableMessage> _messages;

    public User(string name, int age)
    {
        Name = name;
        Age = age;
        _messages = new List<ReadableMessage>();
        Messages = _messages.AsReadOnly();
    }

    public void RecieveMessage(ReadableMessage message)
    {
        _messages.Add(message);
    }

    public MarkAsReadResult MarkAsRead(ReadableMessage message)
    {
        ReadableMessage? foundMessage = Messages.FirstOrDefault(m => m == message);

        if (foundMessage == null) return new MarkAsReadResult.MarkAsReadFailure(new MessageNotFoundError());

        if (foundMessage.IsRead)
        {
            return new MarkAsReadResult.MarkAsReadFailure(new AlreadyReadError());
        }

        foundMessage.IsRead = true;
        return new MarkAsReadResult.MarkAsReadSuccess();
    }
}