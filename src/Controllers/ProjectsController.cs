using AustinSite.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AustinSite.Controllers
{
    public class ProjectsController : Controller
    {
        public IActionResult Index([FromServices] ProjectsRepository projectRep, string searchBy)
        {
            var projects = projectRep.GetProjectList(searchBy);

            ViewBag.SearchBy = searchBy;

            return View(projects);
        }
    }
}