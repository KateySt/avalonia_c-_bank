using System.Collections.Generic;

namespace bank.Models;

public class Transaction
{
    public long Id { set; get; }
    public int countProduct { set; get; }
    public float price { set; get; }
    public ICollection<TransactionProduct> TransactionProducts { get; set; } 
}