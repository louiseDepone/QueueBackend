using Backend.DTO;
using Backend.Models;

namespace Backend.Service.STicket;

public interface ITicketService
{
    void AddTicket(CreateTicketDTO ticket);
    void UpdateTicket(CreateTicketDTO ticket);
    void DeleteTicket(CreateTicketDTO ticket);
    
    Ticket? GetTicketById(int id);
    List<Ticket> GetTickets();
    
    void UpdateStatus(string status,int id);

    // get by NumberAssigned
    Ticket GetTicketByNumberAssigned(int numberAssigned, int departmentId, DateTime date);
}