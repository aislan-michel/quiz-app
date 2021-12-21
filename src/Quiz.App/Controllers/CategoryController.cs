using Microsoft.AspNetCore.Mvc;

namespace Quiz.App.Controllers
{
    public class CategoryController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}