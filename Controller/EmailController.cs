using Backend.Models;
using Backend.Service.SEmail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controller
{
    [Route("/[controller]")]
    [ApiController]
    public class EmailController(EmailService emailService) : ControllerBase
    {
        private readonly EmailService _emailService = emailService;
        [HttpPost]
        public async Task<IActionResult> SendEmail(Email email)
        {
            if(ModelState.IsValid){

            await _emailService.SendEmailAsync(email.ToEmail, email.Subject, email.Message);
            return Ok("Email sent successfully");
            }
            return BadRequest("Invalid model");

        }
    }
}
