using Microsoft.AspNetCore.Mvc;

namespace AustinSite.Controllers
{
    public class ArticlesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}