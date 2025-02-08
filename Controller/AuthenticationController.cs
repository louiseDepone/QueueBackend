using Backend.DTO;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controller;

[Route("[controller]")]
[ApiController]
public class AuthenticationController(QueueDbContext context): ControllerBase
{
  private readonly QueueDbContext _context = context;
  
    [HttpPost("/login")]
    public ActionResult<Account> LoginAccount(LoginDTO credential)
    {
        var user = _context.Account.Include(e => e.Role).Include(e => e.Department).
        FirstOrDefaultAsync(account => account.EmployeeId == credential.EmployeeId && account.Password == credential.Password).Result;
        Console.WriteLine(user);
        if (user is not null)
        {
            return Ok(user);
        }
        return NotFound("User Not Found");
    }
}