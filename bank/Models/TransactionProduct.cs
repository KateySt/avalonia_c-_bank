using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bank.Models;

public class TransactionProduct
{
    [Column("transaction_id")]
    [Required]
    public long TransactionId { get; set; }
    public Transaction Transaction { get; set; }
    [Column("product_id")]
    [Required]
    public int ProductId { get; set; }
    public Product Product { get; set; }
}