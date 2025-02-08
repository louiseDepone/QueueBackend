using System.Collections.Concurrent;
using Backend.Models;

namespace Backend.Hub;
using Microsoft.AspNetCore.SignalR;
public class OnlineAccountHub : Hub
{
    private static readonly Dictionary<string, string?> LoggedInAccounts = new Dictionary<string, string?>();
    public override async Task OnConnectedAsync()
    {
    }

    public async Task Online(string employeeId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, "online");
        await Clients.Caller.SendAsync("onconnected", employeeId);    
        LoggedInAccounts[Context.ConnectionId] = employeeId;
        await Clients.Groups("online").SendAsync("getonlineaccounts", LoggedInAccounts.Values.ToArray());
    }
    
    public async Task GetOnlineAccounts(string employeeId)
    {
        await Clients.Caller.SendAsync("getonlineaccounts", employeeId);
    }
    
    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        LoggedInAccounts.Remove(Context.ConnectionId);
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, "online");
        await Clients.Groups("online").SendAsync("getonlineaccounts", LoggedInAccounts.Values.ToArray());
        await Clients.Caller.SendAsync("onconnected", null);  
    }
    
    public async Task Offline()
    {
        LoggedInAccounts.Remove(Context.ConnectionId);
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, "online");
        await Clients.Groups("online").SendAsync("getonlineaccounts", LoggedInAccounts.Values.ToArray());
        await Clients.Caller.SendAsync("getonlineaccounts", Array.Empty<string>());
        await Clients.Caller.SendAsync("onconnected", null);   
    }
}