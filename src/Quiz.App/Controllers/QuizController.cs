using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Quiz.App.Factories;
using Quiz.App.Infrastructure.Repositories;
using Quiz.App.InputModels;
using Quiz.App.Models;

namespace Quiz.App.Controllers
{
    public class QuizController : Controller
    {
        private static readonly IEnumerable<Question> _questions = QuestionFactory.GenerateList();
        private static int _score;
        private static int _index;
        private static DateTime _start;
        private static DateTime _end;
        private readonly IRepository<Question> _questionRepository;

        public QuizController(IRepository<Question> questionRepository)
        {
            _questionRepository = questionRepository;
        }

        private static TimeSpan TimeDiff => _end - _start;
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StartGame()
        {
            _start = DateTime.Now;

            Console.WriteLine(_start);
            
            return RedirectToAction(nameof(Question));
        }

        public IActionResult Question()
        {
            var question = _questions.FirstOrDefault(x => x.Index == _index);

            if (question is null)
            {
                return RedirectToAction(nameof(Score));
            }

            _index++;

            return View(question);
        }

        public IActionResult SendAnswer(SendAnswer inputModel)
        {
            var question = _questions.First(x => x.Id == inputModel.Id);

            if (question.IsCorrectAnswer(inputModel.Answer))
            {
                _score++;
            }

            return RedirectToAction(nameof(Question));
        }

        public IActionResult Score()
        {
            Console.WriteLine("start {0}", _start);
            Console.WriteLine("end: {0}", _end);
            
            Console.WriteLine("seconds {0}", _start.Second);
            Console.WriteLine("seconds {0}", _end.Second);

            var timeDiff = _end.Second - _start.Second;

            Console.WriteLine("seconds to finish {0}", timeDiff);
            
            return View(new Score(_score, TimeDiff, Guid.NewGuid()));
        }

        public IActionResult Reset()
        {
            _score = 0;
            _index = 0;
            _end = DateTime.Now;

            return RedirectToAction(nameof(Index));
        }
    }
}