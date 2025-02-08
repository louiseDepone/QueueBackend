using System.Text.Json.Serialization;

namespace Backend.Models;

public class TicketFinance
{
    public int Id { get; set; }
    public string? PurposeOfTransaction { get; set; }
    public decimal? CashTendered { get; set; }
    public decimal? AmountToPay { get; set; }
    
    [JsonIgnore]
    public ICollection<Ticket>? Tickets { get; set; }
}