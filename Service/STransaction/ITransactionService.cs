using Backend.DTO;
using Backend.Models;

namespace Backend.Service.STransaction;

public interface ITransactionService
{
    void AddTransaction(CreateTransactionDTO transaction);
    void DeleteTransaction(Transaction transactionId);
    
    List<Transaction> GetTransactions();
    Transaction GetTransactionById(int id);
}