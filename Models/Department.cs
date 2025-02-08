using System.Text.Json.Serialization;

namespace Backend.Models;

public class Department
{
    public int Id { get; set; }
    public string? Name { get; set; } = string.Empty;
    public long? CurrentTicketNumber { get; set; }
    
    [JsonIgnore]
    public ICollection<Account>? Accounts { get; set; }
    
    [JsonIgnore]
    public ICollection<Counter>? Counters { get; set; }
    
    [JsonIgnore]
    public ICollection<Document>? Documents { get; set; }
    
    [JsonIgnore]
    public ICollection<Transaction>? Transactions { get; set; }
    
    [JsonIgnore]
    public ICollection<Ticket>? Tickets { get; set; }
    
    
    
}
