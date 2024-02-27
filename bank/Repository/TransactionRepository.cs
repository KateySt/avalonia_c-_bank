using System.Collections.Generic;
using System.Linq;
using bank.Context;
using bank.Models;

namespace bank.Repository;

public class TransactionRepository()
{
    public void AddTransaction(Transaction transaction)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            db.Transactions.Add(transaction);
            db.SaveChanges();
        }
    }

    public void UpdateTransaction(Transaction transaction)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            db.Transactions.Update(transaction);
            db.SaveChanges();
        }
    }

    public void DeleteTransaction(long transactionId)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            var transaction = db.Transactions.Find(transactionId);
            if (transaction != null)
            {
                db.Transactions.Remove(transaction);
                db.SaveChanges();
            }
        }
    }

    public Transaction GetTransactionById(long transactionId)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            return db.Transactions.Find(transactionId);
        }
    }

    public  List<Transaction> GetAllTransactions()
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            return db.Transactions.ToList();
        }
    }
}