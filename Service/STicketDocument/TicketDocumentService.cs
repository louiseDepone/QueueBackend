using System;
using Backend.DTO;
using Backend.Models;
using Backend.Repository.RTicketDocument;
using Backend.Service.SDocument;

namespace Backend.Service.STicketDocument;

public class TicketDocumentService(ITicketDocumentRepository ticketDocumentRepository
            , IDocumentService documentService
) : ITicketDocumentService
{
    private readonly ITicketDocumentRepository _ticketDocumentRepository = ticketDocumentRepository;
    private readonly IDocumentService _documentService = documentService;

    public TicketDocument AddTicketDocument(CreateTicketDocumentDTO ticketDocumentDTO)
    {
        try
        {
            var document = _documentService.GetDocumentById(ticketDocumentDTO.TypeOfDocument);
            TicketDocument newTicketDocument = new()
            {
                TypeOfDocument = ticketDocumentDTO.TypeOfDocument
            };
            return _ticketDocumentRepository.AddTicketDocument(newTicketDocument);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void DeleteTicketDocument(int id)
    {
        try
        {
            var ticketDocument = GetTicketDocumentById(id);
            _ticketDocumentRepository.DeleteTicketDocument(ticketDocument);
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public TicketDocument GetTicketDocumentById(int ticketDocumentId)
    {
        try
        {
            var ticketDocument = _ticketDocumentRepository.GetTicketDocumentById(ticketDocumentId);
            if (ticketDocument == null)
            {
                throw new Exception("Ticket Document not found");
            }
            return ticketDocument;
        }
        catch (System.Exception)
        {

            throw;
        }
    }

    public List<TicketDocument> GetTicketDocuments()
    {
        return _ticketDocumentRepository.GetTicketDocuments();
    }

    public void UpdateTicketDocument(CreateTicketDocumentDTO ticketDocumentDTO, int ticketDocumentId)
    {
        try
        {
            var ticketDocument = GetTicketDocumentById(ticketDocumentId);
            ticketDocument.TypeOfDocument = ticketDocumentDTO.TypeOfDocument;
            _ticketDocumentRepository.UpdateTicketDocument(ticketDocument);
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}
