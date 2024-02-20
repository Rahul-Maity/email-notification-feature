[HttpPost("register")]
public async Task<IActionResult> Register(UserModel userModel)
{
    try
    {
        // Save user details to database (omitted for brevity)
        // Generate confirmation token
        var confirmationToken = Guid.NewGuid().ToString();

        // Send confirmation email via Elastic Email
        var client = new RestClient("https://api.elasticemail.com/v2/email/send");
        var request = new RestRequest(Method.POST);
        request.AddParameter("apikey", "YOUR_ELASTIC_EMAIL_API_KEY");
        request.AddParameter("from", "noreply@example.com");
        request.AddParameter("fromName", "Your App Name");
        request.AddParameter("subject", "Confirm your email address");
        request.AddParameter("to", userModel.Email);
        request.AddParameter("bodyHtml", $"<p>Please click <a href='http://localhost:4200/confirm/{confirmationToken}'>here</a> to confirm your email address.</p>");
        request.AddParameter("isTransactional", true);
        var response = await client.ExecuteAsync(request);

        if (response.StatusCode == HttpStatusCode.OK)
        {
            return Ok(new { message = "User registered successfully. Confirmation email sent." });
        }
        else
        {
            return StatusCode(500, new { message = "Failed to send confirmation email." });
        }
    }
    catch (Exception ex)
    {
        return StatusCode(500, new { message = "An error occurred while processing your request.", error = ex.Message });
    }
}


