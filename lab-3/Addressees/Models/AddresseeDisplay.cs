using Itmo.ObjectOrientedProgramming.Lab3.Addressees.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.Displays.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.Models;

public class AddresseeDisplay : IAddressee
{
    private readonly Display _display;

    public AddresseeDisplay(Display display)
    {
        _display = display;
    }

    public void RecieveMessage(Message text)
    {
        _display.RecieveMessage(text.Body);
    }
}
