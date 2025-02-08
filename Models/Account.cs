using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Backend.Models;

public class Account
{
    public int Id { get; set; }
    public string? EmployeeId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    
    [ForeignKey("Department")]
    public int? DepartmentId { get; set; }
    public Department? Department { get; set; }
    
    [ForeignKey("Role")]
    public int? RoleId { get; set; }
    public Role? Role { get; set; }
    
    public DateTime? TimeStamped { get; set; }
    
    
    [JsonIgnore]
    public ICollection<Transaction>? Transaction { get; set; }
}