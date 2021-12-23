using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quiz.App.Infrastructure.Repositories;
using Quiz.App.InputModels;
using Quiz.App.Models;

namespace Quiz.App.Controllers
{
    public class QuizController : Controller
    {
        private static int _score;
        private static int _index = 1;
        private static DateTime _start;
        private static DateTime _end;
        private readonly IRepository<Question> _questionRepository;
        private readonly IRepository<Category> _categoryRepository;

        public QuizController(IRepository<Question> questionRepository, IRepository<Category> categoryRepository)
        {
            _questionRepository = questionRepository;
            _categoryRepository = categoryRepository;
        }

        private static TimeSpan TimeDiff => _end - _start;
        
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryRepository.GetDataAsync();
            
            return View(categories);
        }

        public IActionResult StartGame(Guid categoryId)
        {
            _start = DateTime.Now;

            Console.WriteLine(_start);
            
            return RedirectToAction("Question", new { categoryId });
        }

        public async Task<IActionResult> Question(Guid categoryId)
        {
            var question = await _questionRepository.FirstAsync(
                x => x.Index == _index && x.CategoryId == categoryId,
                x => x.Include(y => y.PossibleAnswers));

            if (question is null)
            {
                return RedirectToAction(nameof(Score));
            }

            _index++;

            return View(question);
        }

        public async Task<IActionResult> SendAnswer(SendAnswer inputModel)
        {
            var question = await _questionRepository.FirstAsync(
                x => x.Id == inputModel.Id,
                x => x.Include(y => y.PossibleAnswers));

            if (question.IsCorrectAnswer(inputModel.Answer))
            {
                _score++;
            }

            return RedirectToAction("Question", new{ categoryId = inputModel.CategoryId.ToString() });
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