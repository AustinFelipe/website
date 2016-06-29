using AustinSite.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AustinSite.Controllers
{
    public class ProjectsController : Controller
    {
        public ProjectsRepository ProjectRep { get; }

        public ProjectsController(ProjectsRepository projectRep)
        {
            ProjectRep = projectRep;
        }

        public IActionResult Index(string searchBy)
        {
            var projects = ProjectRep.GetProjectList(searchBy);

            ViewBag.SearchBy = searchBy;

            return View(projects);
        }

        public IActionResult Details(int id)
        {
            var project = ProjectRep.GetProjectById(id);

            if (project == null)
                return BadRequest();

            return View(project);
        }
    }
}