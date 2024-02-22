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

    public User AddUser(User user)
    {
        _userRepository.AddUser(user);
        return user;
    }

    public User CreateOrFindUser(User user)
    {
        if (_userRepository.ExistUser(user))
        {
            return _userRepository.GetUserByName(user.Name);
        }
        _userRepository.AddUser(user);
        return user;
    }
    
    public User UpdateUser(User user)
    {
        _userRepository.UpdateUser(user);
        return user;
    }

    public void DeleteUser(long userId)
    {
        _userRepository.DeleteUser(userId);
    }

    public User GetUserById(long userId)
    {
        return _userRepository.GetUserById(userId);
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _userRepository.GetAllUsers();
    }
}