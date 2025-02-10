using Backend.DTO;
using Backend.Models;
using Backend.Repository.RTransaction;
using Backend.Service.SAccount;
using Backend.Service.SDerpartment;
using Backend.Service.STicket;

namespace Backend.Service.STransaction;

public class TransactionService(
    ITransactionRepository transactionRepository,
    IAccountService accountService,
    IDepartmentService departmentService,
    ITicketService ticketService
    ) : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository = transactionRepository;
    private readonly IAccountService _accountService = accountService;
    private readonly IDepartmentService _departmentService = departmentService;
    private readonly ITicketService _ticketService = ticketService;

    public void AddTransaction(CreateTransactionDTO transaction)
    {
        try
        {
           _departmentService.GetDepartmentById(transaction.DepartmentId);
            _accountService.GetAccountById(transaction.TransactedBy);
            // today date

            var ticket =_ticketService.GetTicketByNumberAssigned(transaction.TicketNumber, transaction.DepartmentId, DateTime.UtcNow, transaction.Location);
            if (ticket.Status == "Completed")
            {
                throw new Exception("Ticket already completed");
            }
            _ticketService.UpdateStatus("Completed", ticket.Id);
            Transaction newTransaction = new()
            {
                DepartmentId = transaction.DepartmentId,
                TransactedBy = transaction.TransactedBy,
                Location = transaction.Location,
                TicketId = ticket.Id,
                TimeStamp = DateTime.UtcNow
            };

            _transactionRepository.AddTransaction(newTransaction);
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }

    public void DeleteTransaction(Transaction transactionId)
    {
        try
        {
            GetTransactionById(transactionId.Id);
            _transactionRepository.DeleteTransaction(transactionId);
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }

    public List<Transaction> GetTransactions()
    {
        try
        {
            return _transactionRepository.GetTransactions();
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }

    public Transaction GetTransactionById(int id)
    {
        try
        {
            var ticket =  _transactionRepository.GetTransactionById(id);
            if (ticket == null)
            {
                throw new Exception("Transaction not found");
            }
            return ticket;
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }

    public List<Transaction> GetTransactionsByDepartmentId(int departmentId)
    {
        try
        {
            _departmentService.GetDepartmentById(departmentId);
            return _transactionRepository.GetTransactionsByDepartmentId(departmentId);   
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }

    public List<Transaction> GetTransactionsByEmployeeId(int employeeId)
    {
        try
        {
            _accountService.GetAccountById(employeeId);
            return _transactionRepository.GetTransactionsByEmployeeId(employeeId);
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }
    
}