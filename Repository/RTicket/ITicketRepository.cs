using Backend.Models;

namespace Backend.Repository.RTicket;

public interface ITicketRepository
{
    
    Ticket AddTicket(Ticket ticket);
    void UpdateTicket(Ticket ticket);
    void DeleteTicket(Ticket ticket);
    
    Ticket? GetTicketById(int id);
    List<Ticket> GetTickets();
    
    Ticket GetTicketByNumberAssigned(int numberAssigned, int departmentId, DateTime date);
    
}