using Lab5.Application.Models.Users;

namespace Lab5.Application.Contracts.Users;

public class CurrentUserService : ICurrentUserService
{
    public User? User { get; set; }

    public void SetCurrentUser(User user)
    {
        User = user;
    }

    public void ClearCurrentUser()
    {
        User = null;
    }
}