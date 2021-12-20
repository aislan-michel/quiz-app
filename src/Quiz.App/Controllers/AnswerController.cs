using Microsoft.AspNetCore.Mvc;

namespace Quiz.App.Controllers
{
    public class AnswerController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
    }
}