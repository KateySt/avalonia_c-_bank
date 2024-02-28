using System.Collections.Generic;
using bank.Models;
using bank.Repository;

namespace bank.Services.Impl;

public class StorageService(StorageRepository storageRepository) : IStorageService
{
    public Storage Add(Storage storage)
    {
        storageRepository.AddStorage(storage);
        return storage;
    }

    public Storage Update(Storage storage)
    {
        storageRepository.UpdateStorage(storage);
        return storage;
    }

    public void Delete(long storageId)
    {
        storageRepository.DeleteStorage(storageId);
    }

    public Storage GetStorageById(long storageId)
    {
        return storageRepository.GetStorageById(storageId);
    }

    public List<Storage> GetAllStorages()
    {
        return storageRepository.GetAllStorages();
    }

    public List<Storage> GetAllStoragesByCompanyId(long companyId)
    {
        return storageRepository.GetAllStoragesByCompanyId(companyId);
    }

    public List<Storage> GetAllStoragesByUserId(long userId)
    {
        return storageRepository.GetAllStoragesByUserId(userId);
    }

    public int countOfProductOnStorage(long storageId)
    {
        return storageRepository.countOfProductOnStorage(storageId);
    }
}