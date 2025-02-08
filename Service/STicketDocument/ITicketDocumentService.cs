using System;
using Backend.DTO;
using Backend.Models;

namespace Backend.Service.STicketDocument;

public interface ITicketDocumentService
{
    TicketDocument GetTicketDocumentById(int ticketDocumentId);
    List<TicketDocument> GetTicketDocuments();
    TicketDocument AddTicketDocument(CreateTicketDocumentDTO ticketDocumentDTO);
    void UpdateTicketDocument(CreateTicketDocumentDTO ticketDocumentDTO, int ticketDocumentId);
    void DeleteTicketDocument(int ticketDocumentId);


}
