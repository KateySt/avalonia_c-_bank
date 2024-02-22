namespace bank.Models;

public class TransactionProduct
{
    public long TransactionId { get; set; }
    public Transaction Transaction { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
}