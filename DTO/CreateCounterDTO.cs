namespace Backend.DTO;

public class CreateCounterDTO
{
    public string? Name { get; set; }
    public string? Type { get; set; }
    public int DepartmentId { get; set; }
    public string? Location { get; set; }
}