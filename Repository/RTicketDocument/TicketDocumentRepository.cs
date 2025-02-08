using System;
using Backend.Models;

namespace Backend.Repository.RTicketDocument;

public class TicketDocumentRepository (QueueDbContext context) : ITicketDocumentRepository
{
    private readonly QueueDbContext _context = context;
    public TicketDocument? AddTicketDocument(TicketDocument ticketDocument)
    {
        _context.TicketDocument.Add(ticketDocument);
        _context.SaveChanges();
        return _context.TicketDocument.FirstOrDefault(a => a.Id == ticketDocument.Id);;
    }

    public void DeleteTicketDocument(TicketDocument ticketDocument)
    {
        _context.TicketDocument.Remove(ticketDocument);
        _context.SaveChanges();
    }

    public TicketDocument? GetTicketDocumentById(int ticketDocumentId)
    {
        return _context.TicketDocument.Find(ticketDocumentId);
    }

    public List<TicketDocument> GetTicketDocuments()
    {
        return _context.TicketDocument.ToList();
    }

    public void UpdateTicketDocument(TicketDocument ticketDocument)
    {
        _context.TicketDocument.Update(ticketDocument);
        _context.SaveChanges();
    }
}
