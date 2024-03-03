using System.Collections.Generic;
using bank.Models;

namespace bank.Services;

public interface ICompanyService
{
    Company Add(Company company);
    Company Update(Company company);
    void Delete(long companyId);
    Company GetCompanyById(long companyId);
    List<Company> GetAllCompanies();
    Company CreateOrFindUser(Company company);
    List<Company> GetAllCompaniesByUserId(long userId);
    List<Company> GetAllCompaniesByUserIdAndStorageId(long userId, long storageId);
    List<Company> GetAllCompaniesByUserIdAndProductId(long userId, long productId);
}