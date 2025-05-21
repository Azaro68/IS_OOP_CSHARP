using Lab5.Application.Contracts.Users;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Login;

public class AdminScenario : IScenario
{
    private readonly IAdminService _adminService;

    public AdminScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Admin Login";

    public void Run()
    {
        string password = AnsiConsole.Prompt(
            new TextPrompt<string>("Enter system password:")
                .Secret());

        if (!_adminService.ValidateAdminPassword(password))
        {
            AnsiConsole.Markup("[red]Invalid password. Exiting system.[/]");
            Environment.Exit(0);
        }

        AnsiConsole.Markup("[green]Admin login successfully![/]");
        AnsiConsole.Markup("Press Enter to continue...");

        AnsiConsole.Console.Input.ReadKey(false);
    }
}