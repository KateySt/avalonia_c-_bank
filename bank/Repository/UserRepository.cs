using System.Collections.Generic;
using System.Linq;
using bank.Context;
using bank.Models;

namespace bank.Repository;

public class UserRepository(ApplicationContext db)
{
    public void AddUser(User user)
    {
        db.Users.Add(user);
        db.SaveChanges();
    }

    public void UpdateUser(User user)
    {
        db.Users.Update(user);
        db.SaveChanges();
    }

    public bool ExistUser(User user)
    {
        return db.Users.Any(u => u.Name == user.Name);
    }

    public void DeleteUser(long userId)
    {
        var user = db.Users.Find(userId);
        if (user != null)
        {
            db.Users.Remove(user);
            db.SaveChanges();
        }
    }

    public User GetUserByName(string name)
    {
        return db.Users.FirstOrDefault(u => u.Name == name);
    }

    public User GetUserById(long userId)
    {
        return db.Users.Find(userId);
    }

    public IEnumerable<User> GetAllUsers()
    {
        return db.Users.ToList();
    }
}