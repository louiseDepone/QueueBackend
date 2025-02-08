using Backend.DTO;
using Backend.Models;

namespace Backend.Service.STicketDocument;

public interface ITicketFinanceService
{
    TicketFinance AddTicketFinance(CreateTicketFinanceDTO ticketFinance);
    void UpdateTicketFinance(CreateTicketFinanceDTO ticketFinance );
    void DeleteTicketFinance(CreateTicketFinanceDTO ticketFinance);
    TicketFinance? GetTicketFinanceById(int id);
    List<TicketFinance> GetTicketFinances();
}