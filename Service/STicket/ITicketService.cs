using Backend.DTO;
using Backend.Models;

namespace Backend.Service.STicket;

public interface ITicketService
{
    void AddTicket(CreateTicketDTO ticket);
    void UpdateTicket(CreateTicketDTO ticket, int id);
    void DeleteTicket(int ticket);
    
    Ticket? GetTicketById(int id);
    List<Ticket> GetTickets();
    
    void UpdateStatus(string status,int id);

    // get by NumberAssigned
    Ticket GetTicketByNumberAssigned(int numberAssigned, int departmentId, DateTime date, string location);


    List<Ticket> GetPendingTickets(int departmentId, DateTime date, string location);
}