using Microsoft.AspNetCore.Mvc;

namespace Quiz.App.Controllers
{
    public class UserController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}