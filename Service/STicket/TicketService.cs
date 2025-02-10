using Backend.DTO;
using Backend.Models;
using Backend.Repository.RTicket;
using Backend.Repository.RTicketDocument;
using Backend.Service.SDerpartment;
using Backend.Service.STicketDocument;

namespace Backend.Service.STicket;

public class TicketService(
    ITicketRepository ticketRepository, 
    ITicketFinanceService ticketFinanceService,
    IDepartmentService departmentService
    ): ITicketService
{
    private readonly ITicketRepository _ticketRepository = ticketRepository;
    private readonly ITicketFinanceService _ticketFinanceService = ticketFinanceService;
    
    private readonly IDepartmentService _departmentService = departmentService;

    public void AddTicket(CreateTicketDTO ticket)
    {
        try
        {
            if ( null == ticket.Departmentid || string.IsNullOrEmpty(ticket.StudentId) ||
                ticket.NumberAssigned == null || string.IsNullOrEmpty(ticket.Email) || string.IsNullOrEmpty(ticket.CounterLocation) )
            {
                throw new Exception("Ticket number assigned AND student Id not provided");
            }

            _departmentService.GetDepartmentById(ticket.Departmentid);
            var newTicket = new Ticket()
            {
                NumberAssigned = ticket.NumberAssigned,
                StudentId = ticket.StudentId,
                Status = "Pending",
                Email = ticket.Email ,
                CounterLocation = ticket.CounterLocation,
                Creation = DateTime.UtcNow,
                DepartmentId = ticket.Departmentid,
            };

            if (ticket.TicketFinance != null)
            {
                var newTicketFinance = _ticketFinanceService.AddTicketFinance(ticket.TicketFinance);
                newTicket.TicketFinance = newTicketFinance;
            }
            
            // DONT FORGET THE DOCUMENT GAGI 
            
            _ticketRepository.AddTicket(newTicket);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Ticket? GetTicketByNumberAssigned(int numberAssigned, int departmentId, DateTime date, string location)
    {
        try
        {
            _departmentService.GetDepartmentById(departmentId);
            var ticket =  _ticketRepository.GetTicketByNumberAssigned(numberAssigned, departmentId, date, location);
            if (ticket == null)
            {
                throw new Exception("Ticket not found");
            }
            return ticket;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void UpdateTicket(CreateTicketDTO ticket)
    {
        try
        {

            throw new NotImplementedException();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void DeleteTicket(int ticket)
    {
        try
        {
            var ticketToDelete = GetTicketById(ticket);
            _ticketRepository.DeleteTicket(ticketToDelete);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Ticket? GetTicketById(int id)
    {
        try
        {
            var idTicker = _ticketRepository.GetTicketById(id);
            if (idTicker == null)
            {
                throw new Exception("Ticket Id not found");
            }
            return _ticketRepository.GetTicketById(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public List<Ticket> GetTickets()
    {
        try
        {
            return _ticketRepository.GetTickets();  
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void UpdateStatus(string status, int id)
    {
        try
        {
            var ticket = _ticketRepository.GetTicketById(id);
            ticket.Status = status;
            _ticketRepository.UpdateTicket(ticket);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public List<Ticket> GetPendingTickets(int departmentId, DateTime date, string location)
    {
        try
        {
            _departmentService.GetDepartmentById(departmentId);
            return _ticketRepository.GetPendingTickets(departmentId, date, location);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}