using Lab5.Application.Contracts.Users;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Login;

public class UserScenario : IScenario
{
    private readonly IUserService _loginService;

    public UserScenario(IUserService loginService)
    {
        _loginService = loginService;
    }

    public string Name => "Client Login";

    public void Run()
    {
        string username = AnsiConsole.Ask<string>("Enter your username:");
        string pin = AnsiConsole.Prompt(new TextPrompt<string>("Enter your PIN:").Secret());

        LoginResult result = _loginService.Login(username, pin);

        HandleResult(result);
    }

    private void HandleResult(LoginResult result)
    {
        string message = result switch
        {
            LoginResult.Success => "Login successful!",
            LoginResult.NotFound => "User not found.",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.MarkupLine($"[green]{message}[/]");
    }
}