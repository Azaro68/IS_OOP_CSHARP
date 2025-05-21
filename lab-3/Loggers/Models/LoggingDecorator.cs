using Itmo.ObjectOrientedProgramming.Lab3.Addressees.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.Loggers.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Loggers.Models;

public class LoggingDecorator
{
    private readonly IAddressee _innerAddressee;
    private readonly ILogger _logger;

    public LoggingDecorator(IAddressee innerAddressee, ILogger logger)
    {
        _innerAddressee = innerAddressee;
        _logger = logger;
    }

    public void RecieveMessage(Message message)
    {
        _logger.Log($"Message received with header: {message.Title}");
        _innerAddressee.RecieveMessage(message);
    }
}