using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Models.Users;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Balance;

public class BalanceScenario : IScenario
{
    private readonly IUserRepository _userRepository;
    private readonly ICurrentUserService _currentUserService;

    public BalanceScenario(IUserRepository userRepository, ICurrentUserService currentUserService)
    {
        _userRepository = userRepository;
        _currentUserService = currentUserService;
    }

    public string Name => "View Balance";

    public void Run()
    {
        User? user = _currentUserService.User;

        if (user is null)
        {
            AnsiConsole.MarkupLine("[red]No user is logged in[/]");
            return;
        }

        decimal balance = _userRepository.GetBalanceByUserId(user.Id).Result;

        string formattedBalance = balance.ToString("C");

        AnsiConsole.MarkupLine($"[green]Current balance is: {formattedBalance}[/]");
    }
}