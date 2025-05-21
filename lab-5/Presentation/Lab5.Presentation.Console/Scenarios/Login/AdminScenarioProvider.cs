using Lab5.Application.Contracts.Users;
using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Console.Scenarios.Login;

public class AdminScenarioProvider : IScenarioProvider
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IAdminService _adminService;

    public AdminScenarioProvider(ICurrentUserService currentUserService, IAdminService adminService)
    {
        _currentUserService = currentUserService;
        _adminService = adminService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUserService.User is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new AdminScenario(_adminService);
        return true;
    }
}