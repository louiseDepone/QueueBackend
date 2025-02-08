using System.Text.Json.Serialization;

namespace Backend.Models;

public class Role
{
    public int Id { get; set; }
    public string? Name { get; set; }
    
    [JsonIgnore ]
    public ICollection<Account>? Accounts { get; set; }
}