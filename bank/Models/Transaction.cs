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
    public int CountProduct { set; get; }
    [Required]
    [Column("date")]
    public int Date { set; get; }
    public List<TransactionProduct>? TransactionProducts { get; set; } = new();
    public List<TransactionCompany>? TransactionCompanies { get; set; } = new();
}