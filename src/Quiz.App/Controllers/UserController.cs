using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quiz.App.InputModels;
using Quiz.App.Mappings;

namespace Quiz.App.Controllers
{
    [Authorize(Roles = "admin")]
    public class UserController : Controller
    {
        public UserController()
        {
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }
            
            var model = inputModel.ToModel();
            
            return RedirectToAction("Details", new {id = model.Id});
        }
        
        public async Task<IActionResult> Details(Guid id)
        {
            return View();
        }
    }
}