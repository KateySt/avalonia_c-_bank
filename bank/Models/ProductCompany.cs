namespace bank.Models;

public class ProductCompany
{
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int CompanyId { get; set; }
    public Company Company { get; set; }
}