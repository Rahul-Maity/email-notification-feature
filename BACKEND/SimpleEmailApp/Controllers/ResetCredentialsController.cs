
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SimpleEmailApp.Models;

namespace SimpleEmailApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResetCredentialsController : ControllerBase
    {
        [HttpPost("reset")]
        public IActionResult ResetCredentials([FromBody] ResetCredentialsModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string userEmail = RegistrationModel.UserEmail;
           
            SendResetCredentialsEmail(userEmail);

            return Ok("Credentials reset successfully.");
        }

        private void SendResetCredentialsEmail(string userEmail)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("mrahulmaity623@gmail.com"));
            email.To.Add(MailboxAddress.Parse(userEmail));
            email.Subject = "Reset Credentials Confirmation";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = GetResetCredentialsEmailBody()
            };
            
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("mrahulmaity623@gmail.com", "phoawtyveyvpdsqd");
            smtp.Send(email);
            smtp.Disconnect(true);
        }

        private string GetResetCredentialsEmailBody()
        {

            return  "<p>Your credentials have been reset successfully!</p>" +
                     "<p>If you did not request this change, please contact our support immediately.</p>" +
                     "<p>Thank you,<br>SimpleEmailApp Team</p>";
        }
    }
}
