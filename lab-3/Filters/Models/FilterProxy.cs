using Itmo.ObjectOrientedProgramming.Lab3.Addressees.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.ImportanceLevels;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Filters.Models;

public class FilterProxy : IAddressee
{
    private readonly IAddressee _innerAddressee;

    public FilterProxy(IAddressee innerAddressee)
    {
        _innerAddressee = innerAddressee;
    }

    public void RecieveMessage(Message text)
    {
        if (text.Importancy >= ImportanceLevel.Medium)
        {
            _innerAddressee.RecieveMessage(text);
        }
    }
}