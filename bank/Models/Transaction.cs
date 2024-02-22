using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bank.Models;

[Table("Transactions")]
public class Transaction
{
    [Column("transaction_id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { set; get; }
    [Required]
    public int countProduct { set; get; }
    [Required]
    public float price { set; get; }
    public ICollection<TransactionProduct> TransactionProducts { get; set; } 
}