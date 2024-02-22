using System.Collections.Generic;

namespace bank.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<ProductCompany> ProductCompanies { get; set; } 
    public ICollection<TransactionProduct> TransactionProducts { get; set; }
}