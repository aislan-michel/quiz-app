using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quiz.App.Infrastructure.Repositories;
using Quiz.App.InputModels;
using Quiz.App.Mappings;
using Quiz.App.Models;

namespace Quiz.App.Controllers
{
    [Authorize(Roles = "admin")]
    public class QuestionController : Controller
    {
        private readonly IRepository<Question> _repository;

        public QuestionController(IRepository<Question> repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var questions = await _repository.GetDataAsync(
                include: x => x.Include(y => y.Category));
            
            return View(questions.OrderBy(x => x.Index));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var question = await _repository.FirstAsync(
                x => x.Id == id, 
                x => x
                    .Include(y => y.PossibleAnswers)
                    .Include(y => y.Category));
            
            return View(question);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateQuestionInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }
            
            var question = inputModel.ToModel();
            
            _repository.Add(question);

            await _repository.SaveAsync();

            return RedirectToAction("Details", new { id = question.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var question = await _repository.FirstAsync(
                x => x.Id == id, 
                x => x
                    .Include(y => y.PossibleAnswers)
                    .Include(y => y.Category));
            
            return View(question);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Guid id, UpdateQuestionInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return View(id.ToString(), inputModel);
            }
            
            var model = await _repository.GetByIdAsync(id);
            
            model.Update(inputModel.Text, inputModel.Index, inputModel.CategoryId);
            
            _repository.Update(model);

            await _repository.SaveAsync();
            
            return RedirectToAction("Details", new {id});
        }

        public async Task<IActionResult> GetText(Guid id)
        {
            var question = await _repository.GetByIdAsync(id);

            return Json(new {text = question.Text});
        }
    }
}