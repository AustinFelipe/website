using Microsoft.AspNetCore.Mvc;

namespace AustinSite.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}