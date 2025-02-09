using System.Transactions;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository.RTransaction;

public class TransactionRepository(QueueDbContext context) : ITransactionRepository
{
    private readonly QueueDbContext _context = context;

    public void AddTransaction(Models.Transaction transaction)
    {
        _context.Transaction.Add(transaction);
        _context.SaveChanges();
    }

    public void DeleteTransaction(Models.Transaction transaction)
    {
        _context.Transaction.Remove(transaction);
        _context.SaveChanges();
    }

    public Models.Transaction? GetTransactionById(int id)
    {
        return _context.Transaction.Include(
            t => t.Department
        ).Include(
            t => t.Ticket
        ).Include(
            t => t.Department
        ).FirstOrDefault(t => t.Id == id);
        
    }

    public List<Models.Transaction> GetTransactions()
    {
        return _context.Transaction.Include(
            t => t.Department
        ).Include(
            t => t.Ticket
        ).Include(
            t => t.Department
        ).ToList();
    }

    public List<Models.Transaction> GetTransactionsByDepartmentId(int departmentId)
    {
        return _context.Transaction.Include(
            t => t.Department
        ).Include(
            t => t.Ticket
        ).Include(
            t => t.Department
        ).Where(t => t.DepartmentId == departmentId).ToList();
    }

    public List<Models.Transaction> GetTransactionsByEmployeeId(int employeeId)
    {
        return _context.Transaction.Include(
            t => t.Department
        ).Include(
            t => t.Ticket
        ).Include(
            t => t.Department
        ).Where(t => t.TransactedBy == employeeId).ToList();
    }

    public void UpdateTransaction(Models.Transaction transaction)
    {
        _context.Transaction.Update(transaction);
        _context.SaveChanges();
    }
}