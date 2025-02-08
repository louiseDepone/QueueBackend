using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public class Counter
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }
    
    [ForeignKey("Department")]
    public int? DepartmentId { get; set; }
    public Department? Department { get; set; }
    
    [ForeignKey("CurrentTicket")]
    public int? CurrentTicketId { get; set; }
    public Ticket? CurrentTicket { get; set; }
    
}