using Backend.DTO;
using Backend.Models;
using Backend.Service.SAccount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controller;
[Route("[controller]")]
[ApiController]
public class AccountController(IAccountService accountService): ControllerBase
{
    private readonly IAccountService _accountService = accountService;
    
    [HttpGet("GetAccounts")]
    public ActionResult<List<Account>> GetAccounts()
    {
        try
        {
            return Ok(_accountService.GetAccounts());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
            throw;
        }
    }

    [HttpGet("GetAccount/{id:int}")]
    public ActionResult<Account> GetAccountById(int id)
    {
        try
        {
            return Ok(_accountService.GetAccountById(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
            throw;
        }
    }

    [HttpPost("AddAccount")]
    public ActionResult AddAccount(CreateAccountDTO accountDTO)
    {
        try
        {
            _accountService.AddAccount(accountDTO);
            return Ok("Account Successfully Added");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
            throw;
        }
    }

    [HttpPut("UpdateAccount/{id:int}")]
    public ActionResult UpdateAccount(CreateAccountDTO accountDTO, int id)
    {
        try
        {
            _accountService.UpdateAccount(accountDTO, id);
            return Ok("Account Successfully Updated");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
            throw;
        }
    }

    [HttpDelete("DeleteAccount/{id:int}")]
    public ActionResult DeleteAccount(int id)
    {
        try
        {
            _accountService.DeleteAccount(id);
            return Ok("Account Successfully Deleted");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
            throw;
        }
    }

    [HttpGet("GetAccountsByRole/{roleId:int}")]
    public ActionResult<List<Account>> GetAccountsByRole(int roleId)
    {
        try
        {
            return Ok(_accountService.GetAccountsByRole(roleId));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
            throw;
        }
    }

}