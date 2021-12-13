using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Quiz.App.Factories;
using Quiz.App.InputModels;
using Quiz.App.Models;

namespace Quiz.App.Controllers
{
    public class QuizController : Controller
    {
        private static readonly IEnumerable<Question> Questions = QuestionFactory.GenerateList();
        //TODO: transform score in a class
        private static int _score = 0;
        private static int _index = 0;
        
        // GET
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Question()
        {
            var question = Questions.FirstOrDefault(x => x.Index == _index);

            if (question is null)
            {
                return RedirectToAction(nameof(Score));
            }

            _index++;

            return View(question);
        }

        public IActionResult SendAnswer(SendAnswer inputModel)
        {
            var question = Questions.First(x => x.Id == inputModel.Id);

            if (question.IsCorrectAnswer(inputModel.Answer))
            {
                _score++;
            }

            return RedirectToAction(nameof(Question));
        }

        public IActionResult Score()
        {
            return View(new Score(_score));
        }

        public IActionResult Reset()
        {
            _score = 0;
            _index = 0;

            return RedirectToAction(nameof(Index));
        }
    }
}