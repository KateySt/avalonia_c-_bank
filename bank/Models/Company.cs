using System.Collections.Generic;

namespace bank.Models;

public class Company
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
    public ICollection<User> Users { get; set; }
    public ICollection<ProductCompany> ProductCompanies { get; set; } 
}