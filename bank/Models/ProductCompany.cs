using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bank.Models;

public class ProductCompany
{
    [Column("product_id")]
    [Required]
    public int ProductId { get; set; }
    public Product Product { get; set; }
    [Column("company_id")]
    [Required]
    public int CompanyId { get; set; }
    public Company Company { get; set; }
}