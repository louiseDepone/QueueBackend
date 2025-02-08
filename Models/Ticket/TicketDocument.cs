using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Backend.Models;

public class TicketDocument
{
    public int Id { get; set; }
    
    [ForeignKey("Document")]
    public int? TypeOfDocument { get; set; }
    public Document? Document { get; set; }
    
    [JsonIgnore]
    public ICollection<Ticket>? Tickets { get; set; }
}