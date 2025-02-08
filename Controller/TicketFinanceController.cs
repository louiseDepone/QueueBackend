using Backend.DTO;
using Backend.Models;
using Backend.Service.STicketDocument;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controller;

[Route("[controller]")]
[ApiController]
public class TicketFinanceController(ITicketFinanceService ticketFinanceService) : ControllerBase
{
    private readonly ITicketFinanceService _ticketFinanceService = ticketFinanceService;

    [HttpGet("GetTicketFinance")]
    public async Task<ActionResult<List<TicketFinance>>> GetTicketFinance()
    {
        try
        {
            return Ok(_ticketFinanceService.GetTicketFinances());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
            throw;
        }
    }
    [HttpGet("GetTicketFinanceById/{id:int}")]
    public async Task<ActionResult<TicketFinance>> GetTicketFinance( int id)
    {
        try
        {
            return Ok(_ticketFinanceService.GetTicketFinanceById(id));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
            throw;
        }
    }
    
    [HttpPost("AddTicketFinance")]
    public async Task<ActionResult> AddTicketFinance(CreateTicketFinanceDTO ticketFinance)
    {
        try
        {
            _ticketFinanceService.AddTicketFinance(ticketFinance);
            return Ok("Successfully added ticket finance");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
            throw;
        }
    }
    
    
}