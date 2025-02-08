using Backend.DTO;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controller;
[Route("[controller]")]
[ApiController]
public class AccountController(QueueDbContext context): ControllerBase
{
    private readonly QueueDbContext _context = context;
    
    [HttpGet("GetAllAccounts")]
    public async Task<ActionResult<List<Account>>> GetAllAccounts()
    {
        var accounts = await _context.Account
            .Include(a => a.Role)
            .Include(a => a.Department)
            .ToListAsync();
        return Ok(accounts);
    }
    
    [HttpPost("Register")]
    public async Task<ActionResult<Account>> CreateAccount(CreateAccountDTO createdAccount)
    {
        if (
            string.IsNullOrEmpty(createdAccount.Email) ||
            string.IsNullOrEmpty(createdAccount.Password) ||
            string.IsNullOrEmpty(createdAccount.EmployeeId) ||
            string.IsNullOrEmpty(createdAccount.LastName) ||
            string.IsNullOrEmpty(createdAccount.FirstName) )
        {
            return BadRequest("Invalid request");
        }
        
        
        var department = await _context.Department.FirstOrDefaultAsync(
            department => department.Id == createdAccount.DepartmentId
        );

        if (department == null)
        {
            return BadRequest("Department not found");
        }
        var role = await _context.Role.FirstOrDefaultAsync(
            role => role.Id == createdAccount.RoleId
        );

        if (role == null)
        {
            return BadRequest("Role not found");
        }
        Account newAccount = new()
        {
            RoleId = createdAccount.RoleId,
            DepartmentId = createdAccount.DepartmentId,
            Email = createdAccount.Email,
            Password = createdAccount.Password,
            FirstName = createdAccount.FirstName,
            LastName = createdAccount.LastName,
            EmployeeId = createdAccount.EmployeeId,
            TimeStamped = DateTime.UtcNow
            
        };
        _context.Account.Add(newAccount);
        await _context.SaveChangesAsync();
        var createdAccountWithDetails = await _context.Account
            .Include(a => a.Role)
            .Include(a => a.Department)
            .FirstOrDefaultAsync(a => a.Id == newAccount.Id);
        
        return Ok(newAccount);
    }

}