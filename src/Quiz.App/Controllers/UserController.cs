using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quiz.App.Infrastructure.Repositories;
using Quiz.App.InputModels;
using Quiz.App.Mappings;
using Quiz.App.Models;

namespace Quiz.App.Controllers
{
    public class UserController : Controller
    {
        public UserController()
        {
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create(CreateUserInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }
            
            var model = inputModel.ToModel();
            
            return RedirectToAction("Details", new {id = model.Id});
        }
        
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Details(Guid id)
        {
            return View();
        }
    }
}