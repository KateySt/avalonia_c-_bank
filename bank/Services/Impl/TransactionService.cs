using System.Collections.Generic;
using bank.Models;
using bank.Repository;

namespace bank.Services.Impl;

public class TransactionService(TransactionRepository transactionRepository) : ITransactionService
{
    public Transaction Add(Transaction transaction)
    {
        transactionRepository.AddTransaction(transaction);
        return transaction;
    }

    public Transaction Update(Transaction transaction)
    {
        transactionRepository.UpdateTransaction(transaction);
        return transaction;
    }

    public void Delete(long transactionId)
    {
        transactionRepository.DeleteTransaction(transactionId);
    }

    public Transaction GetTransactionById(long transactionId)
    {
        return transactionRepository.GetTransactionById(transactionId);
    }

    public  List<Transaction> GetAllTransactions()
    {
        return transactionRepository.GetAllTransactions();
    }
}