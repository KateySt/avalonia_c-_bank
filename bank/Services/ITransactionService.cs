using System.Collections.Generic;
using bank.Models;

namespace bank.Services;

public interface ITransactionService
{
    Transaction Add(Transaction transaction);
    Transaction Update(Transaction transaction);
    void Delete(long transactionId);
    Transaction GetTransactionById(long transactionId);
    IEnumerable<Transaction> GetAllTransactions();
}