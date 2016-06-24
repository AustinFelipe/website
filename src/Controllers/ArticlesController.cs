using AustinSite.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AustinSite.Controllers
{
    public class ArticlesController : Controller
    {
        public IActionResult Index([FromServices] ArticlesRepository articlesRep)
        {
            var articles = articlesRep.Articles;

            return View(articles);
        }
    }
}