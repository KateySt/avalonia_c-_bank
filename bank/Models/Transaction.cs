using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bank.Models;

[Table("transactions")]
public class Transaction
{
    [Key]
    [Column("transaction_id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { set; get; }
    [Required]
    [Column("count_product")]
    public int countProduct { set; get; }
    [Required]
    public float price { set; get; }

    public List<TransactionProduct>? TransactionProducts { get; set; } = new();
}