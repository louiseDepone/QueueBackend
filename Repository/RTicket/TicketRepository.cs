using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository.RTicket;

public class TicketRepository(QueueDbContext context): ITicketRepository
{
    private readonly QueueDbContext _context = context;
    
    public Ticket AddTicket(Ticket ticket)
    {
        _context.Ticket.Add(ticket);
        _context.SaveChanges();
        return _context.Ticket.FirstOrDefault(a => a.Id == ticket.Id);;
    }

    public void UpdateTicket(Ticket ticket)
    {
        _context.Ticket.Update(ticket);
        _context.SaveChanges();
    }

    public void DeleteTicket(Ticket ticket)
    {
        _context.Ticket.Remove(ticket);
    }

    public Ticket? GetTicketById(int id)
    {
        var ticket = _context.Ticket.Include(
                a => a.TicketFinance
            ).Include(a => a.TicketDocument).Include(a => a.Department).FirstOrDefault(a => a.Id == id);
        return ticket;
    }

    public List<Ticket> GetTickets()
    {
        return _context.Ticket.Include(
                a => a.TicketFinance
            ).Include(a => a.TicketDocument).Include(a => a.Department).ToList();
    }

    public Ticket? GetTicketByNumberAssigned(int numberAssigned , int departmentId)
    {
        return _context.Ticket.Include(
                a => a.TicketFinance
            ).Include(a => a.TicketDocument).Include(a => a.Department).FirstOrDefault(a => a.NumberAssigned == numberAssigned && a.DepartmentId == departmentId);
    }


}