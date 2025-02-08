using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public class Document
{
    public int Id { get; set; }
    public string? Name { get; set; }
    
    [ForeignKey("Department")]
    public int? DepartmentId { get; set; }
    public Department? Department { get; set; }
}