﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quiz.App.Infrastructure.Repositories;
using Quiz.App.Models.InputModels;
using Quiz.App.Models.Entities;
using Quiz.App.Models.Mappings;

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
            
            return View(questions.OrderBy(x => x.Index).ToViewModel());
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var question = await _repository.FirstAsync(
                x => x.Id == id, 
                x => x
                    .Include(y => y.PossibleAnswers)
                    .Include(y => y.Category));
            
            return View(question.ToDetailsViewModel());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateQuestionInputModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateQuestionInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }
            
            var entity = inputModel.ToEntity();
            
            _repository.Add(entity);

            await _repository.SaveAsync();

            return RedirectToAction("Create", "Answer", new {questionId = entity.Id});
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var question = await _repository.FirstAsync(
                x => x.Id == id, 
                x => x
                    .Include(y => y.PossibleAnswers)
                    .Include(y => y.Category));
            
            return View(question.ToUpdateViewModel());
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

        public async Task<IActionResult> Simulate(Guid id)
        {
            var question = await _repository.FirstAsync(
                            x => x.Id == id,
                            x => x.Include(y => y.PossibleAnswers));
            
            return View(question.ToSimulateViewModel());
        }

        [HttpGet]
        public async Task<IActionResult> IsCorrectAnswer(Guid questionId, Guid answerId)
        {
            var question = await _repository.FirstAsync(
                x => x.Id == questionId,
                x => x.Include(y => y.PossibleAnswers));

            var correct = question.IsCorrectAnswer(answerId);

            return Json(new {data = correct});
        }
    }
}