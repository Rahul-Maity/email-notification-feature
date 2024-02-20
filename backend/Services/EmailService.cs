using System;
using RestSharp;

public class EmailService
{
    private readonly string _elasticEmailApiKey = "718BED00E5AEB6E524AF6A3885437FDB73DF89C8B2643D47BFB690A7FFF6701ABEAEFFB98172F68204BF128977359C26"; // Replace with your Elastic Email API key

    public void SendEmail(string toEmail, string subject, string body)
    {
        var client = new RestClient("https://api.elasticemail.com");
        var request = new RestRequest("/v2/email/send", Method.Post);
        request.AddParameter("apikey", _elasticEmailApiKey);
        request.AddParameter("from", "mrahulmaity623@gmail.com"); // Replace with your sender email address
        request.AddParameter("to", toEmail);
        request.AddParameter("subject", subject);
        request.AddParameter("bodyHtml", body);

        var response = client.Execute(request);
        if (!response.IsSuccessful)
        {
            throw new Exception($"Failed to send email. Error: {response.ErrorMessage}");
        }
    }
}
