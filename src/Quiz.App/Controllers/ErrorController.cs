using Microsoft.AspNetCore.Mvc;
using Quiz.App.ViewModels;

namespace Quiz.App.Controllers
{
    public class ErrorController : Controller
    {
        // GET
        public IActionResult Index(int statusCode, string message)
        {
            return View(new ErrorViewModel(){StatusCode = statusCode, Message = message});
        }
    }
}