using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiz.App.Infrastructure.Repositories;
using Quiz.App.InputModels;
using Quiz.App.Mappings;
using Quiz.App.Models;

namespace Quiz.App.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IRepository<Question> _repository;

        public QuestionController(IRepository<Question> repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var questions = await _repository.GetDataAsync();
            
            return View(questions.OrderBy(x => x.Index));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            return View(await _repository.GetByIdAsync(id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateQuestionInputModel inputModel)
        {
            var question = inputModel.ToModel();
            
            _repository.Add(question);

            await _repository.SaveAsync();

            return RedirectToAction(nameof(Details), new { id = question.Id });
        }
    }
}