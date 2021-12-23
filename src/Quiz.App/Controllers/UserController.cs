using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiz.App.Infrastructure.Repositories;
using Quiz.App.InputModels;
using Quiz.App.Mappings;
using Quiz.App.Models;

namespace Quiz.App.Controllers
{
    public class UserController : Controller
    {
        private readonly IRepository<User> _repository;

        public UserController(IRepository<User> repository)
        {
            _repository = repository;
        }

        // GET
        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetDataAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Create(CreateUserInputModel inputModel)
        {
            var model = inputModel.ToModel();
            
            _repository.Add(model);

            await _repository.SaveAsync();
            
            return RedirectToAction("Details", new {id = model.Id});
        }

        public async Task<IActionResult> Details(Guid id)
        {
            return View(await _repository.GetByIdAsync(id));
        }
    }
}