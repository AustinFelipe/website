using System.Threading.Tasks;
using AustinSite.Services;
using Microsoft.AspNetCore.Mvc;

namespace AustinSite.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ErrorMessage = TempData["ErrorMessage"]?.ToString();
            ViewBag.SuccessMessage = TempData["SuccessMessage"]?.ToString();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage([FromServices] ContactEmailService contactEmailService,
            string name, 
            string fromEmail, 
            string message)
        {
            try
            {
                await contactEmailService.SendContactFromSite(name, fromEmail, message, "austin.felipe@live.com");
                await contactEmailService.SendSubscriberEmailAsync(name, fromEmail, message);
                TempData["SuccessMessage"] = "Your message has been sent. Thanks for stopping by!";
            }
            catch
            {
                TempData["ErrorMessage"] = "Error trying to send your message. Please, try again later or send an email to austin.felipe@live.com";
            }

            return RedirectToAction("Index");
        }
    }
}