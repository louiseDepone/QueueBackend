using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Backend.Models;

public class Ticket
{
    public int Id { get; set; }
    public long? NumberAssigned { get; set; }
    public string? StudentId { get; set; }
    public string? Email { get; set; }
    public string? CounterLocation { get; set; }
    public string? Status { get; set; } // Pending, Cancelled , Success
    public DateTime Creation { get; set; }
    
    [ForeignKey("TicketDocument")]
    public int? TicketDocumentId { get; set; }
    public TicketFinance? TicketFinance { get; set; }
    
    [ForeignKey("TicketFinance")]
    public int? TicketFinanceId { get; set; }
    public TicketDocument? TicketDocument { get; set; }
    
    [ForeignKey("Department")]
    public int? DepartmentId { get; set; }
    public Department? Department { get; set; }
    
    [JsonIgnore]
    public ICollection<Transaction>? Transaction { get; set; }
    
    [JsonIgnore]
    public ICollection<Counter>? Counter { get; set; }
}