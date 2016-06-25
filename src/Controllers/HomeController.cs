using AustinSite.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AustinSite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index([FromServices] ProjectsRepository projRep,
            [FromServices] ArticlesRepository articleRep)
        {
            var projects = projRep.GetProjectList();
            var articles = articleRep.Articles;
            
            ViewBag.Projects = projects;
            ViewBag.Articles = articles;

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
