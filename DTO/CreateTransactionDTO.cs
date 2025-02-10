namespace Backend.DTO;

public class CreateTransactionDTO
{
    public int TransactedBy { get; set; }
    public int TicketNumber { get; set; }
    public int DepartmentId { get; set; }

    public string Location { get; set; }

}