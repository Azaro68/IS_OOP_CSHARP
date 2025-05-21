using Itmo.ObjectOrientedProgramming.Lab3.Addressees.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Users.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.Models;

public class AddresseeUser : IAddressee
{
    private User User { get; }

    public AddresseeUser(User user)
    {
        User = user;
    }

    public void RecieveMessage(Message text)
    {
        User.RecieveMessage(new ReadableMessage(text));
    }
}