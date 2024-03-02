using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bank.Models;

[Table("product_company")]
public class ProductCompany
{
    [Column("product_id")]
    [Required]
    [ForeignKey("product_id")]
    public long ProductId { get; set; }

    public Product Product { get; set; }

    [Column("company_id")]
    [Required]
    [ForeignKey("company_id")]
    public long CompanyId { get; set; }

    public Company Company { get; set; }
}