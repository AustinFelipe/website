using System.Threading.Tasks;
using AustinSite.Services;
using Microsoft.AspNetCore.Mvc;

namespace AustinSite.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage([FromServices] ContactEmailService contactEmailService,
            string name, 
            string fromEmail, 
            string message)
        {
            await contactEmailService.SendContactFromSite(name, fromEmail, message, "austin.felipe@live.com");
            await contactEmailService.SendSubscriberEmailAsync(name, fromEmail, message);

            return Ok(new { message = "Thanks for stopping by!" });
        }
    }
}