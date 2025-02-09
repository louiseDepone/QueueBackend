using Backend.DTO;
using Backend.Models;
using Backend.Service.STicketDocument;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class TicketDocumentController (ITicketDocumentService ticketDocumentService): ControllerBase
    {
        private readonly ITicketDocumentService _ticketDocumentService = ticketDocumentService;

        [HttpPost("AddTicketDocument")]
        public ActionResult<TicketDocument> AddTicketDocument(CreateTicketDocumentDTO ticketDocumentDTO)
        {
            return _ticketDocumentService.AddTicketDocument(ticketDocumentDTO);
        }

        [HttpDelete("DeleteTicketDocument/{id}")]
        public ActionResult DeleteTicketDocument(int id)
        {
            try
            {
                _ticketDocumentService.DeleteTicketDocument(id);
                return Ok("Ticket Document deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        [HttpGet("GetTicketDocument/{id}")]
        public ActionResult<TicketDocument> GetTicketDocumentById(int id)
        {
            try
            {
                return Ok(_ticketDocumentService.GetTicketDocumentById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);   
                throw;
            }
        }

        [HttpGet("GetTicketDocuments")]
        public ActionResult<List<TicketDocument>> GetTicketDocuments()
        {
            return Ok(_ticketDocumentService.GetTicketDocuments());
        }

        [HttpPut("UpdateTicketDocument/{id}")]
        public ActionResult UpdateTicketDocument(CreateTicketDocumentDTO ticketDocumentDTO, int id)
        {
            try
            {
                _ticketDocumentService.UpdateTicketDocument(ticketDocumentDTO, id);
                return Ok("Ticket Document Updated");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }




    }
}
