using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Models.Users;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.OperationHistory;

public class ViewOperationHistoryScenario : IScenario
{
    private readonly IUserRepository _userRepository;
    private readonly ICurrentUserService _currentUserService;

    public ViewOperationHistoryScenario(IUserRepository userRepository, ICurrentUserService currentUserService)
    {
        _userRepository = userRepository;
        _currentUserService = currentUserService;
    }

    public string Name => "View Operation History";

    public void Run()
    {
        User? user = _currentUserService.User;
        if (user is null)
        {
            AnsiConsole.MarkupLine("[red]You must be logged in to view your operation history.[/]");
            return;
        }

        List<Application.Models.Operations.Operation> operationHistory = _userRepository.GetOperationHistoryByUserId(user.Id).ConfigureAwait(false).GetAwaiter().GetResult();

        if (operationHistory.Count == 0)
        {
            AnsiConsole.MarkupLine("[yellow]No operations found in your history.[/]");
            return;
        }

        var table = new Table();
        table.AddColumn("Operation ID");
        table.AddColumn("Type");
        table.AddColumn("Amount");
        table.AddColumn("Result");

        foreach (Application.Models.Operations.Operation operation in operationHistory)
        {
            table.AddRow(
                operation.OperationId.ToString(),
                operation.OperationType.ToString(),
                operation.Amount.ToString("F2"),
                operation.Result);
        }

        AnsiConsole.Write(table);
    }
}
