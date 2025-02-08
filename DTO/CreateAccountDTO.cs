namespace Backend.DTO;

public class CreateAccountDTO
{
    public string? EmployeeId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public int DepartmentId { get; set; }
    public int RoleId { get; set; }
}