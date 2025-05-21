using Itmo.ObjectOrientedProgramming.Lab3.Addressees.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Messengers.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.Models;

public class AddresseeMessenger : IAddressee
{
    private readonly Messenger _messenger;

    public AddresseeMessenger(Messenger messenger)
    {
        _messenger = messenger;
    }

    public void RecieveMessage(Message text)
    {
        _messenger.RecieveMessage(text.Body);
    }
}