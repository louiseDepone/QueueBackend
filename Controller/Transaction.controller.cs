using Backend.DTO;
using Backend.Models;
using Backend.Service.STransaction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class TransactionController(ITransactionService transactionService) : ControllerBase
    {
        private readonly ITransactionService _transactionService = transactionService;

        [HttpPost]
        public IActionResult AddTransaction(CreateTransactionDTO transaction)
        {
            try
            {
                _transactionService.AddTransaction(transaction);
                return Ok("Transaction added successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteTransaction(Transaction transaction)
        {
            try
            {
                _transactionService.DeleteTransaction(transaction);
                return Ok("Transaction deleted successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetTransactions()
        {
            try
            {
                return Ok(_transactionService.GetTransactions());
            }
            catch ( Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [HttpGet("GettransactionById/{id}")]
        public IActionResult GetTransactionById(int id)
        {
            try
            {
                return Ok(_transactionService.GetTransactionById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("department/{departmentId}")]
        public IActionResult GetTransactionsByDepartmentId(int departmentId)
        {
            try
            {
                return Ok(_transactionService.GetTransactionsByDepartmentId(departmentId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet("employee/{employeeId}")]
        public IActionResult GetTransactionsByEmployeeId(int employeeId)
        {
            try
            {
                return Ok(_transactionService.GetTransactionsByEmployeeId(employeeId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
