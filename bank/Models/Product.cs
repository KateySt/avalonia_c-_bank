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
    [Column("name")]
    public string Name { get; set; }
    [Required]
    [Column("count")]
    public string Count { get; set; }
    public List<ProductCompany>? ProductCompanies { get; set; } = new();
    public List<StorageProduct>? StorageProducts { get; set; } = new();
    public List<TransactionProduct>? TransactionProducts { get; set; } = new();
    public Product(string name, string count)
    {
        Name = name;
        Count = count;
    }
}