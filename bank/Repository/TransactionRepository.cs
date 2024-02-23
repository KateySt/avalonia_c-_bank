using System.Collections.Generic;
using System.Linq;
using bank.Context;
using bank.Models;

namespace bank.Repository;

public class TransactionRepository(ApplicationContext db)
{
    public void AddTransaction(Transaction transaction)
    {
        db.Transactions.Add(transaction);
        db.SaveChanges();
    }

    public void UpdateTransaction(Transaction transaction)
    {
        db.Transactions.Update(transaction);
        db.SaveChanges();
    }

    public void DeleteTransaction(long transactionId)
    {
        var transaction = db.Transactions.Find(transactionId);
        if (transaction != null)
        {
            db.Transactions.Remove(transaction);
            db.SaveChanges();
        }
    }

    public Transaction GetTransactionById(long transactionId)
    {
        return db.Transactions.Find(transactionId);
    }

    public IEnumerable<Transaction> GetAllTransactions()
    {
        return db.Transactions.ToList();
    }
}