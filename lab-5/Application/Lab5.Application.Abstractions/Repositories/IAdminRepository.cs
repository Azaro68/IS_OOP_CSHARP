namespace Lab5.Application.Abstractions.Repositories;

public interface IAdminRepository
{
    Task<string> GetAdminPassword();
}