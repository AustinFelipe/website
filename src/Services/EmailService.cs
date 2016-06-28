using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AustinSite.Services
{
    public class EmailService : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var userMail = Environment.GetEnvironmentVariable("sendGridUser");
            var apiKey = Environment.GetEnvironmentVariable("sendGridApiKey");

            if (string.IsNullOrEmpty(userMail) ||
                string.IsNullOrEmpty(apiKey))
            {
                throw new ArgumentException("sendGridUser || sendGridApiKey");    
            }

            // Plug in your email service here to send an email.
            using(var client = new HttpClient())
            {
                var baseUri = "https://api.sendgrid.com/api/mail.send.json";
                var content = new MultipartFormDataContent(); 
                
                client.BaseAddress = new Uri(baseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                
                content.Add(new StringContent(userMail), "api_user");
                content.Add(new StringContent(apiKey), "api_key");
                content.Add(new StringContent(email), "to");
                content.Add(new StringContent(subject), "subject");
                content.Add(new StringContent(message), "html");
                content.Add(new StringContent("contato@neurando.com"), "from");
                content.Add(new StringContent("Equipe Neurando"), "fromname");
                
                var result = await client.PostAsync(baseUri, content);
            }
        }
    }
}
