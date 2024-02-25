using System.Collections.Generic;
using bank.Models;
using bank.Repository;

namespace bank.Services.Impl;

public class CompanyService(CompanyRepository companyRepository) : ICompanyService
{
    public Company Add(Company company)
    {
        companyRepository.AddCompany(company);
        return company;
    }

    public Company Update(Company company)
    {
        companyRepository.UpdateCompany(company);
        return company;
    }

    public void Delete(long companyId)
    {
        companyRepository.DeleteCompany(companyId);
    }

    public Company GetCompanyById(long companyId)
    {
        return companyRepository.GetCompanyById(companyId);
    }

    public IEnumerable<Company> GetAllCompanies()
    {
        return companyRepository.GetAllCompanies();
    }

    public Company CreateOrFindUser(Company company)
    {
        if ( companyRepository.ExistCompany(company))
        {
            return  companyRepository.GetCompanyByName(company.Name);
        }
        companyRepository.AddCompany(company);
        return company;
    }

    public IEnumerable<Company> GetAllCompaniesByUserId(long userId)
    {
        return companyRepository.GetAllCompaniesByUserId(userId);
    }
}