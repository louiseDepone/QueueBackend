using Backend.Models;

namespace Backend.Repository.RTransaction;

public interface ITransactionRepository
{
    void AddTransaction(Transaction transaction);
    void DeleteTransaction(Transaction transaction);

    void UpdateTransaction(Transaction transaction);
    
    List<Transaction> GetTransactions();
    Transaction GetTransactionById(int id);

    List<Transaction> GetTransactionsByDepartmentId(int departmentId);

    List<Transaction> GetTransactionsByEmployeeId(int employeeId);
}