using AustinSite.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AustinSite.Controllers
{
    public class ArticlesController : Controller
    {
        public IActionResult Index([FromServices] ArticlesRepository articlesRep, string searchBy)
        {
            var articles = articlesRep.GetArticlesByTitleAndTag(searchBy);

            ViewBag.SearchBy = searchBy;

            return View(articles);
        }
    }
}