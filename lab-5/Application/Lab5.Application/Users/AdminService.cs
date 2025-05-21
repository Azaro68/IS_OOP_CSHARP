using Lab5.Application.Contracts.Users;

namespace Lab5.Application.Users;

public class AdminService : IAdminService
{
    private readonly AdminPasswordService _adminPasswordService;

    public AdminService(AdminPasswordService adminPasswordService)
    {
        _adminPasswordService = adminPasswordService;
    }

    public bool ValidateAdminPassword(string password)
    {
        string storedPassword = _adminPasswordService.AdminPassword;
        return storedPassword == password;
    }
}
