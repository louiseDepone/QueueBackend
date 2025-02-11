using System;

namespace Backend.Models;

public class Email
{
   public string? ToEmail { get; set; }
    public string? Subject { get; set; }
    public string? Message { get; set; }
}
