using Backend.Models;

namespace Backend.Repository.RTicketDocument;

public class TicketFinanceRepository(QueueDbContext context): ITicketFinanceRepository
{
    private readonly QueueDbContext _context = context;

    public TicketFinance AddTicketFinance(TicketFinance ticketFinance)
    {
        _context.TicketFinance.Add(ticketFinance);
        _context.SaveChanges();
        return _context.TicketFinance.FirstOrDefault(a => a.Id == ticketFinance.Id);;
    }

    public void UpdateTicketFinance(TicketFinance ticketFinance)
    {
        
        _context.TicketFinance.Update(ticketFinance);
        _context.SaveChanges();
    }

    public void DeleteTicketFinance(TicketFinance ticketFinance)
    {
        _context.TicketFinance.Remove(ticketFinance);
        _context.SaveChanges();
        
    }

    public TicketFinance? GetTicketFinanceById(int id)
    {
        return _context.TicketFinance.Find(id);
    }

    public List<TicketFinance> GetTicketFinances()
    {
        return _context.TicketFinance.ToList();
    }
}