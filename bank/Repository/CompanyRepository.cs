using System.Collections.Generic;
using System.Linq;
using bank.Context;
using bank.Models;

namespace bank.Repository;

public class CompanyRepository()
{
    public void AddCompany(Company company)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            db.Companies.Add(company);
            db.SaveChanges();
        }
    }

    public void UpdateCompany(Company company)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            db.Companies.Update(company);
            db.SaveChanges();
        }
    }

    public bool ExistCompany(Company company)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            return db.Companies.Any(c => c.Name == company.Name);
        }
    }

    public void DeleteCompany(long companyId)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            var company = db.Companies.Find(companyId);
            if (company != null)
            {
                db.Companies.Remove(company);
                db.SaveChanges();
            }
        }
    }
    
    public Company GetCompanyByName(string name)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            return db.Companies.FirstOrDefault(c => c.Name == name);
        }
    }
    
    public Company GetCompanyById(long companyId)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            return db.Companies.Find(companyId);
        }
    }

    public  List<Company> GetAllCompanies()
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            return db.Companies.ToList();
        }
    }
    
    public  List<Company> GetAllCompaniesByUserId(long userId)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            return db.Companies.Where(c => c.User != null && c.User.Id == userId).ToList();
        }
    }
}