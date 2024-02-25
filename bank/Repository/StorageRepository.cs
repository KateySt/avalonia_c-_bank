using System;
using System.Collections.Generic;
using System.Linq;
using bank.Context;
using bank.Models;

namespace bank.Repository;

public class StorageRepository(ApplicationContext db)
{
    public void AddStorage(Storage storage)
    {
        db.Storages.Add(storage);
        db.SaveChanges();
    }

    public void UpdateStorage(Storage storage)
    {
        db.Storages.Update(storage);
        db.SaveChanges();
    }

    public bool ExistStorage(Storage storage)
    {
        return db.Storages.Any(s => s.Name == storage.Name);
    }

    public void DeleteStorage(long storageId)
    {
        var storage = db.Storages.Find(storageId);
        if (storage != null)
        {
            db.Storages.Remove(storage);
            db.SaveChanges();
        }
    }
    
    public Storage GetStorageByName(string name)
    {
        return db.Storages.FirstOrDefault(s =>s.Name == name);
    }
    
    public Storage GetStorageById(long storageId)
    {
        return db.Storages.Find(storageId);
    }

    public IEnumerable<Storage> GetAllStorages()
    {
        return db.Storages.ToList();
    }
    
    public IEnumerable<Storage> GetAllStoragesByCompanyId(long companyId)
    {
        return db.Storages.Where(c => c.Company != null && c.Company.Id==companyId).ToList();
    }
}