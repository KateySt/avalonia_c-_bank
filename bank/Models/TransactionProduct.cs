using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bank.Models;

[Table("transaction_product")]
public class TransactionProduct
{
    [Column("transaction_id")]
    [Required]
    [ForeignKey("transaction_id")]
    public long TransactionId { get; set; }
    public Transaction Transaction { get; set; }
    [Column("product_id")]
    [Required]
    [ForeignKey("product_id")]
    public long ProductId { get; set; }
    public Product Product { get; set; }
}