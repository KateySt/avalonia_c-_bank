using System.Collections.Generic;
using bank.Models;

namespace bank.Services;

public interface IStorageService
{
    Storage Add(Storage storage);
    Storage Update(Storage storage);
    void Delete(long storageId);
    Storage GetStorageById(long storageId);
    List<Storage> GetAllStorages();
    List<Storage> GetAllStoragesByCompanyId(long companyId);
    List<Storage> GetAllStoragesByUserId(long userId);
    int countOfProductOnStorage(long storageId);
}