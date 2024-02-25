using System.Collections.Generic;
using bank.Models;

namespace bank.Services;

public interface ICompanyService
{
    Company Add(Company company);
    Company Update(Company company);
    void Delete(long companyId);
    Company GetCompanyById(long companyId);
    IEnumerable<Company> GetAllCompanies();
    Company CreateOrFindUser(Company company);
    IEnumerable<Company> GetAllCompaniesByUserId(long userId);
}