using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Models.Users;
using Spectre.Console;
using System.Runtime.CompilerServices;

namespace Lab5.Presentation.Console.Scenarios.Balance;

public class WithdrawalBalanceScenario : IScenario
{
    private readonly IUserRepository _userRepository;
    private readonly ICurrentUserService _currentUserService;

    public WithdrawalBalanceScenario(IUserRepository userRepository, ICurrentUserService currentUserService)
    {
        _userRepository = userRepository;
        _currentUserService = currentUserService;
    }

    public string Name => "Withdrawal balance";

    public void Run()
    {
        User? user = _currentUserService.User;
        if (user is null)
        {
            AnsiConsole.MarkupLine("[red]You must be logged in to withdrawal your balance.[/]");
            return;
        }

        decimal amount = AnsiConsole.Ask<decimal>("[green]Enter the amount to withdrawal your balance:[/]");
        ConfiguredTaskAwaitable<bool> success = _userRepository.WithdrawBalance(user.Id, amount).ConfigureAwait(true);

        if (success.GetAwaiter().GetResult())
        {
            AnsiConsole.MarkupLine($"[green]Your balance has been successfully withdrawaled by {amount}.[/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red]Failed to withdrawal your balance.[/]");
        }
    }
}