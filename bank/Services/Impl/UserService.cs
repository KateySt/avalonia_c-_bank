using System.Collections.Generic;
using bank.Models;
using bank.Repository;

namespace bank.Services.Impl;

public class UserService : IUserService
{
    private readonly UserRepository _userRepository;

    public UserService(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void AddUser(User user)
    {
        _userRepository.AddUser(user);
    }

    public void UpdateUser(User user)
    {
        _userRepository.UpdateUser(user);
    }

    public void DeleteUser(int userId)
    {
        _userRepository.DeleteUser(userId);
    }

    public User GetUserById(int userId)
    {
        return _userRepository.GetUserById(userId);
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _userRepository.GetAllUsers();
    }
}