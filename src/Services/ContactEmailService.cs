using System.Collections.Generic;
using System.Threading.Tasks;
using AustinSite.Utils;
using Microsoft.Extensions.Caching.Memory;

namespace AustinSite.Services
{
    public class ContactEmailService
    {
        private IEmailService emailService;
        private IMemoryCache memoryCache;

        public ContactEmailService(IEmailService emailService,
            IMemoryCache memoryCache)
        {
            this.emailService = emailService;
            this.memoryCache = memoryCache;
        }

        public async Task SendContactFromSite(string name, 
            string fromEmail, 
            string message,
            string ownerEmail)
        {
            Dictionary<string, string> templateData = new Dictionary<string, string>
            {
                { "name", name.GetFirstName() },
                { "email", fromEmail },
                { "message", message }
            };

            var template = RazorUtils.RenderViewToString(memoryCache, 
                "ContactViaSite", 
                templateData,
                $"{name} contact you via Austin's site. Their email {fromEmail}. Their message {message}");

            try
            {
                await emailService.SendEmailAsync(ownerEmail, 
                    "Contact via Austin's Site", 
                    template);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public async Task SendSubscriberEmailAsync(string name, 
            string fromEmail, 
            string message)
        {
            Dictionary<string, string> templateData = new Dictionary<string, string>
            {
                { "name", name.GetFirstName() }
            };

            var template = RazorUtils.RenderViewToString(memoryCache, 
                "ThanksMessage", 
                templateData,
                $"Hi {name.GetFirstName()}, I've received your message. As soon as possible, I will answer you.");

            try
            {
                await emailService.SendEmailAsync(fromEmail, 
                    "I've received your message", 
                    template);    
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
    }
}