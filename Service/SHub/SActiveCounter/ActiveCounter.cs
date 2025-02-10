using System;

namespace Backend.Service.SHub.SActiveCounter;


using Backend.DTO;
using Backend.Service.SAccount;
using Backend.Service.SCounter;
using Backend.Service.SDerpartment;
using Backend.Service.STicket;
using Backend.Service.STransaction;
using Microsoft.AspNetCore.SignalR;
public class ActiveCounter
    (ICounterService counterService,
        IDepartmentService departmentService,
        ITicketService ticketService,
        ITransactionService transactionService,
        IAccountService accountService
    ) : Hub
{
    private readonly ICounterService _counterService = counterService;
    private readonly IDepartmentService _departmentService = departmentService;
    private readonly ITicketService _ticketService = ticketService;
    private readonly ITransactionService _transactionService = transactionService;
    private readonly IAccountService _accountService = accountService;
    public override async Task OnConnectedAsync()
    {
        var allcounters = _counterService.GetCounters();
        await Clients.All.SendAsync("getallcounter", allcounters);
    }

    // Make Active The Existing Counter
    public async Task ActiveTheCounter(int counterId)
    {
        var counter = _counterService.UpdateCounterAvailability(counterId, true);
        var currentNumberOfDepartment = _departmentService.GetDepartmentById(counter.DepartmentId);
        var allCounterLocation = _counterService.GetCounterByLocation(counter.DepartmentId, counter.Location);
        var allcounterDepartment = _counterService.GetCounterByDepartmentId(counter.DepartmentId);
        var allcounters = _counterService.GetCounters();
        // GET ALL THE TICKET BASE ON THE NUMBER
        var TICKETlINEDuP = _ticketService.GetPendingTickets(counter.DepartmentId,
            DateTime.UtcNow, counter.Location);

        if (currentNumberOfDepartment.CurrentTicketNumber == null)
        {
            _departmentService.UpdateDepartmentCurrentNumber(currentNumberOfDepartment.Id, 0);

        }

        await Groups.AddToGroupAsync(Context.ConnectionId, currentNumberOfDepartment.Name + counter.Location);
        await Groups.AddToGroupAsync(Context.ConnectionId, currentNumberOfDepartment.Name);
        await Clients.Group(currentNumberOfDepartment.Name + counter.Location).SendAsync("getnextfivetickets", TICKETlINEDuP.Count > 5 ? TICKETlINEDuP.GetRange(0, 5) : TICKETlINEDuP);
        await Clients.Group(currentNumberOfDepartment.Name + counter.Location).SendAsync("getlocationcounter", allCounterLocation);
        await Clients.Caller.SendAsync("getcounternumber", 0);
        await Clients.Group(currentNumberOfDepartment.Name).SendAsync("getdepartmentticketnumber", currentNumberOfDepartment.CurrentTicketNumber);
        await Clients.Group(currentNumberOfDepartment.Name).SendAsync("getdepartmentcounter", allcounterDepartment);
        await Clients.All.SendAsync("getallcounter", allcounters);
    }

    // next ticket
    public async Task NextTicket(int counterId)
    {
        var counter = _counterService.UpdateCounterAvailability(counterId, true);
        var currentNumberOfDepartment = _departmentService.GetDepartmentById(counter.DepartmentId);
        var   allCounterLocation = _counterService.GetCounterByLocation(counter.DepartmentId, counter.Location);
        var allcounterDepartment = _counterService.GetCounterByDepartmentId(counter.DepartmentId);
        

        // GET ALL THE TICKET BASE ON THE NUMBER
        var TICKETlINEDuP = _ticketService.GetPendingTickets(counter.DepartmentId, DateTime.UtcNow, counter.Location);

        if (TICKETlINEDuP.Count < 1)
        {
            _counterService.UpdateCounterTicket(counterId, null);
        }
        if (TICKETlINEDuP.Count > 0)
        {
            var nextTicket = _ticketService.GetPendingTickets(counter.DepartmentId, DateTime.UtcNow, counter.Location).First();
            _ticketService.UpdateStatus("Processing", nextTicket.Id);
            _departmentService.UpdateDepartmentCurrentNumber(currentNumberOfDepartment.Id, nextTicket.NumberAssigned);
            _counterService.UpdateCounterTicket(counterId, nextTicket.Id);
        }
        var allcounters = _counterService.GetCounters();
        await Clients.Caller.SendAsync("getcounternumber", TICKETlINEDuP.Count > 0 ? TICKETlINEDuP.First() : null);
        await Clients.Group(currentNumberOfDepartment.Name + counter.Location).SendAsync("getnextfivetickets", TICKETlINEDuP.Count > 5 ? TICKETlINEDuP.GetRange(0, 5) : TICKETlINEDuP);
        await Clients.Group(currentNumberOfDepartment.Name).SendAsync("getdepartmentticketnumber", currentNumberOfDepartment.CurrentTicketNumber);
        await Clients.Group(currentNumberOfDepartment.Name + counter.Location).SendAsync("getlocationcounter", allCounterLocation);
        await Clients.Group(currentNumberOfDepartment.Name).SendAsync("getdepartmentcounter", allcounterDepartment);
        await Clients.All.SendAsync("getallcounter", allcounters);
    }

    public async Task CompleteTicket(int accountId, int counterId, int ticketId)
    {
        var account = _accountService.GetAccountById(accountId);
        var counter = _counterService.GetCounterById(counterId);

        var transaction = new CreateTransactionDTO()
        {
            DepartmentId = counter.DepartmentId,
            Location = counter.Location,
            TicketNumber = ticketId,
            TransactedBy = accountId
        };

        _transactionService.AddTransaction(transaction);


    }

    public async Task CloseCounter(int counterId)
    {
        var counter = _counterService.UpdateCounterAvailability(counterId, false);
        var currentNumberOfDepartment = _departmentService.GetDepartmentById(counter.DepartmentId);
        var allCounterLocation = _counterService.GetCounterByLocation(counter.DepartmentId, counter.Location);
        var allcounterDepartment = _counterService.GetCounterByDepartmentId(counter.DepartmentId);
        var allcounters = _counterService.GetCounters();

        await Groups.RemoveFromGroupAsync(Context.ConnectionId, currentNumberOfDepartment.Name + counter.Location);
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, currentNumberOfDepartment.Name);

        await Clients.Group(currentNumberOfDepartment.Name + counter.Location).SendAsync("getlocationcounter", allCounterLocation);
        await Clients.Group(currentNumberOfDepartment.Name).SendAsync("getdepartmentcounter", allcounterDepartment);
        await Clients.All.SendAsync("getallcounter", allcounters);
    }

}
