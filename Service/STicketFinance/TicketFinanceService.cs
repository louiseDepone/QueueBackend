using Backend.DTO;
using Backend.Models;
using Backend.Repository.RTicketDocument;

namespace Backend.Service.STicketDocument;



public class TicketFinanceService(ITicketFinanceRepository ticketFinanceRepository) : ITicketFinanceService
{
    private readonly ITicketFinanceRepository _ticketFinanceRepository = ticketFinanceRepository;

    public TicketFinance AddTicketFinance(CreateTicketFinanceDTO ticketFinance)
    {
        try
        {
            var newTicketFinance = new TicketFinance()
            {
                PurposeOfTransaction = ticketFinance.PurposeOfTransaction,
                CashTendered = ticketFinance.CashTendered,
                AmountToPay = ticketFinance.AmountToPay
            };
            return _ticketFinanceRepository.AddTicketFinance(newTicketFinance);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
   
        
    }

    public void UpdateTicketFinance(CreateTicketFinanceDTO ticketFinance)
    {
        try
        {
            throw new NotImplementedException();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void DeleteTicketFinance(CreateTicketFinanceDTO ticketFinance)
    {
        try
        {
            throw new NotImplementedException();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }    
    }

    public TicketFinance? GetTicketFinanceById(int id)
    {        
        try
        {
            var ticket = _ticketFinanceRepository.GetTicketFinanceById(id);
            if (ticket == null)
            {
                throw new Exception($"Ticket finance with id {id} not found");
            }
            return ticket;
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public List<TicketFinance> GetTicketFinances()
    {
        try
        {
           return  _ticketFinanceRepository.GetTicketFinances();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}