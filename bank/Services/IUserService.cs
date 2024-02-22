using System.Collections.Generic;
using bank.Models;

namespace bank.Services;

public interface IUserService
{
    User AddUser(User user);
    User UpdateUser(User user);
    void DeleteUser(long userId);
    User GetUserById(long userId);
    IEnumerable<User> GetAllUsers();
    User CreateOrFindUser(User user);
}