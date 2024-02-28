using System.Collections.Generic;
using System.Linq;
using bank.Context;
using bank.Models;

namespace bank.Repository;

public class UserRepository()
{
    public void AddUser(User user)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            db.Users.Add(user);
            db.SaveChanges();
        }
    }

    public void UpdateUser(User user)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            db.Users.Update(user);
            db.SaveChanges();
        }
    }

    public bool ExistUser(User user)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            return db.Users.Any(u => u.Name == user.Name);
        }
    }

    public void DeleteUser(long userId)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            var user = db.Users.Find(userId);
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }
    }

    public User GetUserByNameAndPassword(string name, string password)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            return db.Users.FirstOrDefault(u => u.Name == name && u.Password == password);
        }
    }

    public User GetUserById(long userId)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            return db.Users.Find(userId);
        }
    }

    public  List<User> GetAllUsers()
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            return db.Users.ToList();
        }
    }
}