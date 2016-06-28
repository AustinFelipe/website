using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace AustinSite.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("credentials.json", optional: true)
                .Build();
            var userMail = config["sendGridUser"];
            var apiKey = config["sendGridApiKey"];

            if (string.IsNullOrEmpty(userMail))
            {
                throw new ArgumentException("sendGridUser");    
            }

            if (string.IsNullOrEmpty(apiKey))
            {
                throw new ArgumentException("sendGridApiKey");    
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
                content.Add(new StringContent("austin.felipe@live.com"), "from");
                content.Add(new StringContent("Austin Felipe"), "fromname");
                
                var result = await client.PostAsync(baseUri, content);

                if (result.StatusCode != HttpStatusCode.OK)
                    throw new Exception("Error trying to send an email");
            }
        }
    }
}
