using System.Collections.Generic;
using bank.Models;

namespace bank.Services;

public interface IUserService
{
    User Add(User user);
    User Update(User user);
    void Delete(long userId);
    User GetUserById(long userId);
    IEnumerable<User> GetAllUsers();
    User CreateOrFindUser(User user);
}