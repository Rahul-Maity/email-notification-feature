using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using SimpleEmailApp.Models;

namespace SimpleEmailApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResetCredentialsController:ControllerBase
    {
        [HttpPost("reset")]
        public string ResetCredentials([FromBody] ResetCredentialsModel model)
        {
            string userEmail = RegistrationModel.UserEmail;
            SendEmail(userEmail);
            return "Credentials reset successfully.";
        }

        private void SendEmail(string userEmail)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("mrahulmaity623@gmail.com"));
            email.To.Add(MailboxAddress.Parse(userEmail));
            email.Subject = "Reset Credentials Confirmation";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = "Your credentials have been reset successfully!"
            };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("mrahulmaity623@gmail.com", "phoawtyveyvpdsqd");
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
    //public class ResetCredentialsModel
    //{
    //    public string Name { get; set; }
    //    public string Email { get; set; }
    //    public string Password { get; set; }
    //    // Add other fields as needed for updating user information
    //}
}
