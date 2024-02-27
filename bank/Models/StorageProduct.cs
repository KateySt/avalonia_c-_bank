using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bank.Models;

[Table("storage_product")]
public class StorageProduct
{
    [Column("storage_id")]
    [Required]
    [ForeignKey("storage_id")]
    public long StorageId { get; set; }

    public Storage Storage { get; set; }

    [Column("product_id")]
    [Required]
    [ForeignKey("product_id")]
    public long ProductId { get; set; }

    public Product Product { get; set; }
}