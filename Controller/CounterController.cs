using Backend.DTO;
using Backend.Service.SCounter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class CounterController(ICounterService counterService) : ControllerBase
    {
        private readonly ICounterService _counterService = counterService;

        [HttpPost("AddCounter")]
        public IActionResult AddCounter(CreateCounterDTO counterDTO)
        {
            try
            {
                _counterService.AddCounter(counterDTO);
                return Ok("Counter added successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("DeleteCounter/{id:int}")]
        public IActionResult DeleteCounter(int id)
        {
            try
            {
                _counterService.DeleteCounter(id);
                return Ok("Counter deleted successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetCounters")]
        public IActionResult GetCounters()
        {
            try
            {
                return Ok(_counterService.GetCounters());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetCounterById/{id}")]
        public IActionResult GetCounterById(int id)
        {
            try
            {
                return Ok(_counterService.GetCounterById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("UpdateCounter/{id}")]
        public IActionResult UpdateCounter(CreateCounterDTO counterDTO, int id)
        {
            try
            {
                _counterService.UpdateCounter(counterDTO, id);
                return Ok("Counter updated successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        [HttpGet("GetCounterByDepartmentId")]
        public IActionResult GetCounterByDepartmentId([FromQuery] int departmentId)
        {
            try
            {
                return Ok(_counterService.GetCounterByDepartmentId(departmentId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetCounterByNameAndLocation")]
        public IActionResult GetCounterByNameAndLocation(
      [FromQuery] string name,
      [FromQuery] string location,
      [FromQuery] int departmentId)
        {
            try
            {
                return Ok(_counterService.GetCounterByNameAndLocation(name, location, departmentId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("GetCounterByLocation")]
        public IActionResult GetCounterByLocation([FromQuery] int department, [FromQuery] string location)
        {
            try
            {
                return Ok(_counterService.GetCounterByLocation(department, location));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}
