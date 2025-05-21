using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Models.Users;

namespace Lab5.Application.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public LoginResult Login(string username, string pincode)
    {
        User? user = _userRepository.FindUserByUsername(username).Result;

        if (user is not null && user.Username == username)
        {
            return new LoginResult.Success();
        }

        return new LoginResult.NotFound();
    }
}