using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public class Transaction
{
    public int Id { get; set; }
    public DateTime TimeStamp { get; set; }
    
    [ForeignKey("Account")]
    public int? TransactedBy { get; set; }
    public Account? Account { get; set; }
    
    [ForeignKey("Ticket")] 
    public int TicketId { get; set; }
    public Ticket? Ticket { get; set; }
    
    [ForeignKey("Department")]
    public int? DepartmentId { get; set; }
    public Department? Department { get; set; }
}
