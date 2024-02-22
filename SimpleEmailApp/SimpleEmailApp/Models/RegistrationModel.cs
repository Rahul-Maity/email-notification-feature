namespace SimpleEmailApp.Models
{
    public class RegistrationModel
    {
           public string Name { get; set; }
           public string Email { get; set; }
           public string Password { get; set; }
        public static string UserEmail { get; set; }
    }
}
