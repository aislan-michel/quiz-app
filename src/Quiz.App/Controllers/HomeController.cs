using Microsoft.AspNetCore.Mvc;
using Quiz.App.Models.ViewModels;

namespace Quiz.App.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode, string message)
        {
            return View(new ErrorViewModel(){StatusCode = statusCode, Message = message});
        }
    }
}