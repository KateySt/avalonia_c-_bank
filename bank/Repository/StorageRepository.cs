using System;
using System.Collections.Generic;
using System.Linq;
using bank.Context;
using bank.Models;

namespace bank.Repository;

public class StorageRepository()
{
    public void AddStorage(Storage storage)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            db.Storages.Add(storage);
            db.SaveChanges();
        }
    }

    public void UpdateStorage(Storage storage)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            db.Storages.Update(storage);
            db.SaveChanges();
        }
    }

    public bool ExistStorage(Storage storage)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            return db.Storages.Any(s => s.Name == storage.Name);
        }
    }

    public void DeleteStorage(long storageId)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            var storage = db.Storages.Find(storageId);
            if (storage != null)
            {
                db.Storages.Remove(storage);
                db.SaveChanges();
            }
        }
    }

    public Storage GetStorageByName(string name)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            return db.Storages.FirstOrDefault(s => s.Name == name);
        }
    }

    public Storage GetStorageById(long storageId)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            return db.Storages.Find(storageId);
        }
    }

    public List<Storage> GetAllStorages()
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            return db.Storages.ToList();
        }
    }

    public List<Storage> GetAllStoragesByCompanyId(long companyId)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            return db.Storages.Where(c => c.Company != null && c.Company.Id == companyId).ToList();
        }
    }

    public List<Storage> GetAllStoragesByUserId(long userId)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            return db.Storages.Where(c => c.Company.User != null && c.Company.User.Id == userId).ToList();
        }
    }

    public int countOfProductOnStorage(long storageId)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            return db.Storages.Count(s => s.StorageProducts.Any(s=>s.StorageId==storageId));
        }
    }
}