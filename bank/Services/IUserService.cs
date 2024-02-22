using System.Collections.Generic;
using bank.Models;

namespace bank.Services;

public interface IUserService
{
    void AddUser(User user);
    void UpdateUser(User user);
    void DeleteUser(int userId);
    User GetUserById(int userId);
    IEnumerable<User> GetAllUsers();
}