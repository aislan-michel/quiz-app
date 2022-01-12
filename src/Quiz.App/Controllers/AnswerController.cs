using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quiz.App.Infrastructure.Repositories;
using Quiz.App.Models.InputModels;
using Quiz.App.Mappings;
using Quiz.App.Models.Entities;

namespace Quiz.App.Controllers
{
    [Authorize(Roles = "admin")]
    public class AnswerController : Controller
    {
        private readonly IRepository<PossibleAnswer> _repository;

        public AnswerController(IRepository<PossibleAnswer> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Create(Guid questionId)
        {
            var inputModel = new CreateAnswerInputModel {QuestionId = questionId};
            
            return View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAnswerInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }
            
            var model = inputModel.ToModel();
            
            _repository.AddRange(model);

            await _repository.SaveAsync();

            return RedirectToAction("Details", "Question", new { id = inputModel.QuestionId});
        }
    }
}