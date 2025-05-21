using FluentMigrator.Runner;
using Itmo.Dev.Platform.Postgres.Connection;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Models.Users;
using Lab5.Application.Users;
using Lab5.Infrastructure.DataAccess.ConnectionProvider;
using Lab5.Infrastructure.DataAccess.Migrations;
using Lab5.Infrastructure.DataAccess.Repositories;
using Lab5.Presentation.Console;
using Lab5.Presentation.Console.Scenarios.Balance;
using Lab5.Presentation.Console.Scenarios.Login;
using Lab5.Presentation.Console.Scenarios.OperationHistory;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;
using LoginResult = Lab5.Application.Contracts.Users.LoginResult;

namespace Lab5.Run;

public class Program
{
    public static void Main(string[] args)
    {
        IServiceCollection services = ConfigureServices();

        using ServiceProvider serviceProvider = services.BuildServiceProvider();
        RunMigrations(serviceProvider);

        RunApplication(serviceProvider);
    }

    public static IServiceCollection ConfigureServices()
    {
        return new ServiceCollection()
            .AddFluentMigratorCore()
            .ConfigureRunner(runner => runner
                .AddPostgres()
                .WithGlobalConnectionString(GetConnectionString())
                .ScanIn(typeof(Initial).Assembly).For.Migrations())
            .AddLogging(logging => logging.AddFluentMigratorConsole())
            .AddSingleton<IAdminRepository, AdminRepository>()
            .AddSingleton<IUserRepository, UserRepository>()
            .AddSingleton<IAdminService, AdminService>()
            .AddSingleton<IUserService, UserService>()
            .AddSingleton<ICurrentUserService, CurrentUserService>()
            .AddSingleton<IScenarioProvider, BalanceScenarioProvider>()
            .AddSingleton<IScenarioProvider, ReplenishBalanceScenarioProvider>()
            .AddSingleton<IScenarioProvider, WithdrawalBalanceScenarioProvider>()
            .AddSingleton<IScenarioProvider, UserScenarioProvider>()
            .AddSingleton<IScenarioProvider, AdminScenarioProvider>()
            .AddSingleton<ScenarioRunner>()
            .AddSingleton<ReplenishBalanceScenario>()
            .AddSingleton<WithdrawalBalanceScenario>()
            .AddSingleton<ViewOperationHistoryScenario>()
            .AddSingleton<IPostgresConnectionProvider>(provider => new PostgresConnectionProvider(GetConnectionString()))
            .AddSingleton<AdminPasswordService>(provider => new AdminPasswordService("secret_password"));
    }

    private static readonly string[] Value = new[]
    {
        "Host=localhost",
        "Port=5432",
        "Database=postgres",
        "Username=postgres",
        "Password=postgres",
    };

    private static string GetConnectionString()
    {
        return string.Join(";", Value);
    }

    private static void RunMigrations(ServiceProvider serviceProvider)
    {
        using IServiceScope scope = serviceProvider.CreateScope();
        IMigrationRunner runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

        Console.WriteLine("Starting migration...");
        runner.MigrateUp();
        Console.WriteLine("Migration completed successfully!");
    }

    private static void RunApplication(ServiceProvider serviceProvider)
    {
        while (true)
        {
            int mainChoice = AnsiConsole.Prompt(
                new SelectionPrompt<int>()
                    .Title("Choose an option:")
                    .AddChoices(1, 2, 3)
                    .UseConverter(x => x switch
                    {
                        1 => "Login as Admin",
                        2 => "Login as User",
                        3 => "Exit",
                        _ => "Unknown",
                    }));

            switch (mainChoice)
            {
                case 1:
                    RunAdminMenu(serviceProvider);
                    break;
                case 2:
                    RunUserMenu(serviceProvider);
                    break;
                case 3:
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    private static void RunAdminMenu(ServiceProvider serviceProvider)
    {
        LoginAsAdmin(serviceProvider);

        while (true)
        {
            int adminChoice = AnsiConsole.Prompt(
                new SelectionPrompt<int>()
                    .Title("Admin Menu:")
                    .AddChoices(1, 2, 3)
                    .UseConverter(x => x switch
                    {
                        1 => "Add New User",
                        2 => "Return to Main Menu",
                        _ => "Unknown",
                    }));

            switch (adminChoice)
            {
                case 1:
                    AddUser(serviceProvider);
                    break;
                case 2:
                    return;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    private static void RunUserMenu(ServiceProvider serviceProvider)
    {
        LoginAsUser(serviceProvider);

        while (true)
        {
            int userChoice = AnsiConsole.Prompt(
                new SelectionPrompt<int>()
                    .Title("User Menu:")
                    .AddChoices(1, 2, 3, 4)
                    .UseConverter(x => x switch
                    {
                        1 => "Deposit Money",
                        2 => "Withdraw Money",
                        3 => "View Balance",
                        4 => "View Operation History",
                        5 => "Return to Main Menu",
                        _ => "Unknown",
                    }));

            switch (userChoice)
            {
                case 1:
                    DepositMoney(serviceProvider);
                    break;
                case 2:
                    WithdrawMoney(serviceProvider);
                    break;
                case 3:
                    ShowBalance(serviceProvider);
                    break;
                case 4:
                    ShowHistory(serviceProvider);
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    private static void LoginAsAdmin(ServiceProvider serviceProvider)
    {
        IAdminService adminService = serviceProvider.GetRequiredService<IAdminService>();
        var adminScenario = new AdminScenario(adminService);
        adminScenario.Run();
    }

    private static void LoginAsUser(ServiceProvider serviceProvider)
    {
        IUserService userService = serviceProvider.GetRequiredService<IUserService>();
        ICurrentUserService currentUserService = serviceProvider.GetRequiredService<ICurrentUserService>();
        IUserRepository userRepository = serviceProvider.GetRequiredService<IUserRepository>();

        string username = AnsiConsole.Ask<string>("Enter your username:");
        string pincode = AnsiConsole.Prompt(
            new TextPrompt<string>("Enter your pincode:")
                .Secret());

        Lab5.Application.Contracts.Users.LoginResult result = userService.Login(username, pincode);
        if (result is LoginResult.Success)
        {
            Console.WriteLine($"Welcome, {username}!");
            currentUserService.User = userRepository.FindUserByUsername(username).Result;
            serviceProvider.GetRequiredService<ScenarioRunner>().Run();
        }
        else
        {
            Console.WriteLine("Invalid username or pincode.");
        }
    }

    private static void AddUser(ServiceProvider serviceProvider)
    {
        IUserRepository userRepository = serviceProvider.GetRequiredService<IUserRepository>();

        string username = AnsiConsole.Ask<string>("Enter new user's username:");
        string pincode = AnsiConsole.Prompt(
            new TextPrompt<string>("Enter new user's pincode:")
                .Secret());

        var newUser = new User(Id: 0, Username: username, Pincode: pincode);
        userRepository.Add(newUser);
        Console.WriteLine($"User {username} added successfully!");
    }

    private static void DepositMoney(ServiceProvider serviceProvider)
    {
        ReplenishBalanceScenario depositScenario = serviceProvider.GetRequiredService<ReplenishBalanceScenario>();
        depositScenario.Run();
    }

    private static void WithdrawMoney(ServiceProvider serviceProvider)
    {
        WithdrawalBalanceScenario withdrawScenario = serviceProvider.GetRequiredService<WithdrawalBalanceScenario>();
        withdrawScenario.Run();
    }

    private static void ShowHistory(ServiceProvider serviceProvider)
    {
        ViewOperationHistoryScenario showHistoryScenario =
            serviceProvider.GetRequiredService<ViewOperationHistoryScenario>();
        showHistoryScenario.Run();
    }

    private static void ShowBalance(ServiceProvider serviceProvider)
    {
        BalanceScenario balanceScenario = serviceProvider.GetRequiredService<BalanceScenario>();
        balanceScenario.Run();
    }
}
