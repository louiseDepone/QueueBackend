using Backend.Models;

namespace Backend.Repository.RTicketDocument;

public interface ITicketFinanceRepository
{
    TicketFinance AddTicketFinance(TicketFinance ticketFinance);
    void UpdateTicketFinance(TicketFinance ticketFinance );
    void DeleteTicketFinance(TicketFinance ticketFinance);
    TicketFinance? GetTicketFinanceById(int id);
    List<TicketFinance> GetTicketFinances();
    
    
}