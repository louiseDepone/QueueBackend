using Backend.DTO;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controller;

[Route("[controller]")]
[ApiController]
public class RoleController(QueueDbContext context): ControllerBase
{
    private readonly QueueDbContext _context = context;
    
    [HttpPost("AddRole")]
    public async Task<ActionResult<Role>> AddDepartment(CreateRoleDTO newRoleDtoDto)
    {
        var newRole = new Role()
        {
            Name = newRoleDtoDto.Name
        };
        _context.Role.Add(newRole);
        await _context.SaveChangesAsync();
        return newRole;
    }

    [HttpGet("GetAllRoles")]
    public async Task<ActionResult<List<Role>>> GetAllRoles()
    {
        return await _context.Role.ToListAsync();
    }
}