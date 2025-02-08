using Backend.DTO;
using Backend.Models;
using Backend.Repository.RDepartment;
using Backend.Service.SDerpartment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controller;


[Route("[controller]")]
[ApiController]
public class DepartmentController(IDepartmentService departmentService): ControllerBase
{
    private readonly IDepartmentService _departmentService = departmentService;
     
    [HttpPost("AddDepartment")]
    public async Task<ActionResult> AddDepartment(CreateDepartmentDTO newDepartmentDto)
    {
        try
        {
            _departmentService.AddDepartment(newDepartmentDto);
            return Created();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    
    [HttpGet("GetAllDepartments")]
    public async Task<ActionResult<List<Department>>> GetAllDepartments()
    {
        return Ok(_departmentService.GetAllDepartments());
    }

    [HttpDelete("DeleteDepartment/{id:int}")]
    public async Task<ActionResult> DeleteDepartment(int id)
    {
        try
        {
            _departmentService.DeleteDepartment(id);
            return Ok("Successfuly deleted");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
            throw;
        }
    }
    
    [HttpPut("EditDepartment/{id:int}")]
    public async Task<ActionResult<List<Department>>> GetDepartmentById(CreateDepartmentDTO editedDepartmentDto,int id)
    {
        try
        {
            _departmentService.UpdateDepartment(editedDepartmentDto, id);
            return Ok("Succesfully updated");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
            throw;
        }
    }
    
 
}