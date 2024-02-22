using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bank.Models;

[Table("products")]
public class Product
{
    [Key]
    [Column("product_id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    [Required]
    public string Name { get; set; }
    public ICollection<ProductCompany>? ProductCompanies { get; set; } 
    public ICollection<TransactionProduct>? TransactionProducts { get; set; }
}