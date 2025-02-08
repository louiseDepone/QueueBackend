using Backend.Models;

namespace Backend.Repository.RTransaction;

public interface ITransactionRepository
{
    void AddTransaction(Transaction transaction);
    void DeleteTransaction(Transaction transaction);
    
    List<Transaction> GetTransactions();
    Transaction GetTransactionById(int id);
}