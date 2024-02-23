using System.Collections.Generic;
using System.Linq;
using bank.Context;
using bank.Models;

namespace bank.Repository;

public class CompanyRepository(ApplicationContext db)
{
    public void AddCompany(Company company)
    {
        db.Companies.Add(company);
        db.SaveChanges();
    }

    public void UpdateCompany(Company company)
    {
        db.Companies.Update(company);
        db.SaveChanges();
    }

    public bool ExistCompany(Company company)
    {
        return db.Companies.Any(c => c.Name == company.Name);
    }

    public void DeleteCompany(long companyId)
    {
        var company = db.Companies.Find(companyId);
        if (company != null)
        {
            db.Companies.Remove(company);
            db.SaveChanges();
        }
    }
    
    public Company GetCompanyByName(string name)
    {
        return db.Companies.FirstOrDefault(c => c.Name == name);
    }
    
    public Company GetCompanyById(long companyId)
    {
        return db.Companies.Find(companyId);
    }

    public IEnumerable<Company> GetAllCompanies()
    {
        return db.Companies.ToList();
    }
}