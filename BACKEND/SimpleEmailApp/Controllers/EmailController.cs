

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

                // Get the appropriate email template based on the scenario
                string subject = "Registration Confirmation";
                string body = GetRegistrationConfirmationEmailBody(userEmail);

                SendEmail(userEmail, subject, body);

                return Ok();
            }

            private string GetRegistrationConfirmationEmailBody(string userEmail)   
            {
                // Customize the email body with a personalized greeting and instructions
                return $"<p>Dear {userEmail},</p>" +
                       "<p>Thank you for registering with us!</p>" +
                       "<p>You're all set to start using our services.</p>" +
                       "<ol>" +
                       "<li>Log in to your account using your credentials.</li>" +
                       "<li>Explore our platform and start using our features.</li>" +
                       "</ol>" +
                       "<p>If you have any questions or need assistance, feel free to contact our support team.</p>" +
                       "<p>Best regards,<br>SimpleEmailApp Team</p>";
            }

            private void SendEmail(string userEmail, string subject, string body)
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("mrahulmaity623@gmail.com"));
                email.To.Add(MailboxAddress.Parse(userEmail));
                email.Subject = subject;
                email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = body
                };
                    
                using var smtp = new SmtpClient();
                smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate("mrahulmaity623@gmail.com", "phoawtyveyvpdsqd");
                smtp.Send(email);
                smtp.Disconnect(true);
            }
        }
    }
