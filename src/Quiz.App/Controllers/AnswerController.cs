﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiz.App.Infrastructure.Repositories;
using Quiz.App.InputModels;
using Quiz.App.Mappings;
using Quiz.App.Models;

namespace Quiz.App.Controllers
{
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
            var inputModel = new CreateAnswerInputModel() {QuestionId = questionId};
            
            return View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAnswerInputModel inputModel)
        {
            var model = inputModel.ToModel();
            
            _repository.AddRange(model);

            await _repository.SaveAsync();

            return RedirectToAction("Index", "Question");
        }
    }
}