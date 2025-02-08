namespace Backend.DTO;

public class CreateTicketFinanceDTO
{
    public decimal? AmountToPay { get; set; }
    public decimal? CashTendered { get; set; }
    public string? PurposeOfTransaction { get; set; }
}