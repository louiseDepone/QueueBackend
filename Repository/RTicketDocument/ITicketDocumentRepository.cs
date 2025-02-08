using System;
using Backend.Models;

namespace Backend.Repository.RTicketDocument;

public interface ITicketDocumentRepository
{
    TicketDocument AddTicketDocument(TicketDocument ticketDocument);
    void UpdateTicketDocument(TicketDocument ticketDocument);
    void DeleteTicketDocument(TicketDocument ticketDocument);
    TicketDocument? GetTicketDocumentById(int ticketDocumentId);
    List<TicketDocument> GetTicketDocuments();



}
