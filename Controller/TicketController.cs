using Backend.DTO;
using Backend.Models;
using Backend.Repository.RTicket;
using Backend.Service.STicket;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controller;
[Route("[controller]")]
[ApiController]
public class TicketController(ITicketService ticketService):ControllerBase
{
    private readonly ITicketService _ticketService = ticketService;

    [HttpGet("GetAllTickets")]
    public async Task<ActionResult>  GetAllTickets()
    {
        try
        {
           return Ok(_ticketService.GetTickets());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
            throw;
        }
    }

    [HttpPost("AddTicket")]
    public async Task<ActionResult> AddTicket(CreateTicketDTO ticketDto)
    {
        try
        {
            _ticketService.AddTicket(ticketDto);
            return Ok("Ticket Successfully Added");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
            throw;
        }
    }
    
    [HttpGet("GetTicket/{id:int}")]
    public async Task<ActionResult>  GetTicketbyId(int id)
    {
        try
        {
            return Ok(_ticketService.GetTicketById(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
            throw;
        }
    }
}