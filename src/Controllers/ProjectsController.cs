using Microsoft.AspNetCore.Mvc;

namespace AustinSite.Controllers
{
    public class ProjectsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}