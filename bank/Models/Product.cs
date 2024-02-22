using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bank.Models;

[Table("Products")]
public class Product
{
    [Column("product_id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public ICollection<ProductCompany> ProductCompanies { get; set; } 
    public ICollection<TransactionProduct> TransactionProducts { get; set; }
}