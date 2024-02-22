using System.Collections.Generic;
using System.Linq;
using bank.Models;

namespace bank.Repository;

public class UserRepository
{ 
    private readonly ApplicationContext _db;

    public UserRepository(ApplicationContext db)
    {
        _db = db;
    }

    public void AddUser(User user)
    {
        _db.Users.Add(user);
        _db.SaveChanges();
    }

    public void UpdateUser(User user)
    {
        _db.Users.Update(user);
        _db.SaveChanges();
    }

    public void DeleteUser(int userId)
    {
        var user = _db.Users.Find(userId);
        if (user != null)
        {
            _db.Users.Remove(user);
            _db.SaveChanges();
        }
    }

    public User GetUserById(int userId)
    {
        return _db.Users.Find(userId);
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _db.Users.ToList();
    }
}