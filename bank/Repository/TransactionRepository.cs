using System;
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
            transaction.Date = DateTime.SpecifyKind(transaction.Date, DateTimeKind.Utc);
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
    
    public List<Transaction> GetAllTransactionsByProductId(long productId, long userId)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            return db.Transactions
                .Where(t => t.TransactionCompanies != null
                            && t.TransactionProducts != null
                            && t.TransactionProducts.Any(tp => tp.ProductId == productId)
                            && t.TransactionCompanies.Any(tc => tc.Company.User != null && 
                                                               tc.Company.User.Id == userId))
                .ToList();
        }
    }
    
    public List<Transaction> GetAllTransactionsByUserId(long userId)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            return db.Transactions
                .Where(t => t.TransactionCompanies != null
                            && t.TransactionCompanies.Any(tc => tc.Company.User != null && 
                                                                tc.Company.User.Id == userId))
                .ToList();
        }
    }
}