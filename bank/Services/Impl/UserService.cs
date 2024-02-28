using System.Collections.Generic;
using bank.Models;
using bank.Repository;

namespace bank.Services.Impl;

public class UserService(UserRepository userRepository) : IUserService
{
    public User Add(User user)
    {
        userRepository.AddUser(user);
        return user;
    }

    public User CreateOrFindUser(User user)
    {
        if (userRepository.ExistUser(user))
        {
            return userRepository.GetUserByNameAndPassword(user.Name, user.Password);
        }
        userRepository.AddUser(user);
        return user;
    }
    
    public User Update(User user)
    {
        userRepository.UpdateUser(user);
        return user;
    }

    public void Delete(long userId)
    {
        userRepository.DeleteUser(userId);
    }

    public User GetUserById(long userId)
    {
        return userRepository.GetUserById(userId);
    }

    public  List<User> GetAllUsers()
    {
        return userRepository.GetAllUsers();
    }
}