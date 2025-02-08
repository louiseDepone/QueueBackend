using Backend.DTO;
using Backend.Models;
using Backend.Service.SRole;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controller;

[Route("[controller]")]
[ApiController]
public class RoleController(IRoleService roleService): ControllerBase
{
    private readonly IRoleService _roleService = roleService;
    
    // ALL please
    [HttpGet("GetAllRoles")]
    public ActionResult<List<Role>> GetAllRoles()
    {
        try
        {
            return Ok(_roleService.GetRoles());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
            throw;
        }
    }

    // add a role
    [HttpPost("AddRole")]
    public ActionResult AddRole(CreateRoleDTO roleDTO)
    {
        try
        {
            _roleService.AddRole(roleDTO);
            return Ok("Role Successfully Added");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
            throw;
        }
    }

    // get a role by id
    [HttpGet("GetRole/{id:int}")]
    public ActionResult<Role> GetRoleById(int id)
    {
        try
        {
            return Ok(_roleService.GetRoleById(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
            throw;
        }
    }

    // update a role
    [HttpPut("UpdateRole/{id:int}")]
    public ActionResult UpdateRole(CreateRoleDTO roleDTO, int id)
    {
        try
        {
            _roleService.UpdateRole(roleDTO, id);
            return Ok("Role Updated");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
            throw;
        }
    }

    // delete a role
    [HttpDelete("DeleteRole/{id:int}")]
    public ActionResult DeleteRole(int id)
    {
        try
        {
            _roleService.DeleteRole(id);
            return Ok("Role Deleted");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
            throw;
        }
    }


    


}