using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Users;
using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Console.Scenarios.OperationHistory;

public class ViewOperationHistoryScenarioProvider : IScenarioProvider
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IUserRepository _userRepository;

    public ViewOperationHistoryScenarioProvider(ICurrentUserService currentUserService, IUserRepository userRepository)
    {
        _currentUserService = currentUserService;
        _userRepository = userRepository;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUserService.User is null)
        {
            scenario = null;
            return false;
        }

        scenario = new ViewOperationHistoryScenario(_userRepository, _currentUserService);
        return true;
    }
}