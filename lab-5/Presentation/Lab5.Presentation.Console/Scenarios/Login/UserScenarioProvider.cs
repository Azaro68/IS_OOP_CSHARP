using Lab5.Application.Contracts.Users;
using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Console.Scenarios.Login;

public class UserScenarioProvider : IScenarioProvider
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IUserService _userService;

    public UserScenarioProvider(ICurrentUserService currentUserService, IUserService userService)
    {
        _currentUserService = currentUserService;
        _userService = userService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUserService.User is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new UserScenario(_userService);
        return true;
    }
}