using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bank.Models;

[Table("transaction_company")]
public class TransactionCompany
{
    [Column("transaction_id")]
    [Required]
    [ForeignKey("transaction_id")]
    public long TransactionId { get; set; }

    public Transaction Transaction { get; set; }

    [Column("company_id")]
    [Required]
    [ForeignKey("company_id")]
    public long CompanyId { get; set; }

    public Company Company { get; set; }
}