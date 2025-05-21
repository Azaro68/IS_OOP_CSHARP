using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Models.Users;
using Spectre.Console;
using System.Runtime.CompilerServices;

namespace Lab5.Presentation.Console.Scenarios.Balance;

public class ReplenishBalanceScenario : IScenario
{
    private readonly IUserRepository _userRepository;
    private readonly ICurrentUserService _currentUserService;

    public ReplenishBalanceScenario(IUserRepository userRepository, ICurrentUserService currentUserService)
    {
        _userRepository = userRepository;
        _currentUserService = currentUserService;
    }

    public string Name => "Replenish balance";

    public void Run()
    {
        User? user = _currentUserService.User;
        if (user is null)
        {
            AnsiConsole.MarkupLine("[red]You must be logged in to replenish your balance.[/]");
            return;
        }

        decimal amount = AnsiConsole.Ask<decimal>("[green]Enter the amount to replenish your balance:[/]");
        ConfiguredTaskAwaitable<bool> success = _userRepository.ReplenishBalance(user.Id, amount).ConfigureAwait(true);

        if (success.GetAwaiter().GetResult())
        {
            AnsiConsole.MarkupLine($"[green]Your balance has been successfully replenished by {amount}.[/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red]Failed to replenish your balance.[/]");
        }
    }
}