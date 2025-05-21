namespace Lab5.Application.Contracts.Users;

public interface IAdminService
{
    bool ValidateAdminPassword(string password);
}