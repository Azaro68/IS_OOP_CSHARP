namespace Lab5.Application.Users;

public class AdminPasswordService
{
    public string AdminPassword { get; set; }

    public AdminPasswordService(string adminPassword)
    {
        AdminPassword = adminPassword;
    }
}
