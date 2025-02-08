
namespace Backend.Hub;
using Microsoft.AspNetCore.SignalR;

public class typeHub
{
    public long CurrentNumber { get; set; }
    public Dictionary<string, long>? OpenCounters { get; set; }
}
public class ActiveCounterHub : Hub
{
    private static readonly Dictionary<string, typeHub> Departments = new Dictionary<string, typeHub>();
    
    public override async Task OnConnectedAsync()
    {
    }
    public async Task OpenCounter(string departmentName, string counterName)
    {
        var containsKey = Departments.ContainsKey(departmentName);
        if (!containsKey)
        {
            var newDepartment = new typeHub()
            {
                CurrentNumber = 0,
                OpenCounters = []
            };
            Departments.Add(departmentName, newDepartment);
            Departments[departmentName].OpenCounters?.Add(counterName,Departments[departmentName].CurrentNumber);
        }
        else
        {
            if (!Departments[departmentName].OpenCounters.ContainsKey(counterName))
            {
                Departments[departmentName].OpenCounters?.Add(counterName,++Departments[departmentName].CurrentNumber);
            }
        }
        
        await Groups.AddToGroupAsync(Context.ConnectionId, departmentName);
        //await Clients.Groups(departmentName).SendAsync("getnumber", Departments[departmentName]);
        await Clients.All.SendAsync("getnumber", Departments[departmentName]);
        await Clients.All.SendAsync("displayallinformation", Departments);
        await Clients.All.SendAsync("getallopendepartment", Departments.Keys.ToArray());
    }
    
    public async Task NextTicket(string departmentName, string counterName)
    {
       Departments[departmentName].OpenCounters[counterName] = ++Departments[departmentName].CurrentNumber;
       // await Clients.Groups(departmentName).SendAsync("getnumber", Departments[departmentName]);
       await Clients.All.SendAsync("getnumber", Departments[departmentName]);
       
       await Clients.All.SendAsync("displayallinformation", Departments);
    }
    
    public async Task PreviousTicket(string departmentName)
    {
        Departments[departmentName].CurrentNumber--;
        await Clients.Groups(departmentName).SendAsync("getnumber", Departments[departmentName]);
    }

    public async Task CloseDepartment(string departmentName)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, departmentName);
    }
}