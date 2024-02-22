using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SimpleEmailApp.Models;

namespace SimpleEmailApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        [HttpPost]
        public IActionResult Register([FromBody] RegistrationModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            RegistrationModel.UserEmail = model.Email;
         
            string userEmail = model.Email;

            
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("mrahulmaity623@gmail.com")); 
            email.To.Add(MailboxAddress.Parse(userEmail)); 
            email.Subject = "Registration Confirmation";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = "Thank you for registering!"
            };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("mrahulmaity623@gmail.com", "phoawtyveyvpdsqd"); 
            smtp.Send(email);
            smtp.Disconnect(true);

            return Ok();
        }
    }
    //public class RegistrationModel
    //{
    //    public string Name { get; set; }
    //    public string Email { get; set; }
    //    public string Password { get; set; }
       
    //}
}
