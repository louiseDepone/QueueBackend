namespace Backend.DTO;

public class CreateTicketDTO
{
    public int? NumberAssigned { get; set; }
    public string? StudentId { get; set; }
    public string? Email { get; set; }
    public CreateTicketDocumentDTO? TicketDocument {
        get;
        set;
    }
    public CreateTicketFinanceDTO? TicketFinance { get; set; }
    public int Departmentid { get; set; }
    public string? CounterLocation { get; set; }
}