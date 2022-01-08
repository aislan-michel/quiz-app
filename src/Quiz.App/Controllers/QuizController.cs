using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quiz.App.Extensions;
using Quiz.App.Infrastructure.Repositories;
using Quiz.App.InputModels;
using Quiz.App.Mappings;
using Quiz.App.Models;

namespace Quiz.App.Controllers
{
    [Authorize]
    public class QuizController : Controller
    {
        private static int _score;
        private static int _index = 1;
        private DateTime _start;
        private DateTime _end;
        private readonly IRepository<Question> _questionRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Score> _scoreRepository;

        public QuizController(
            IRepository<Question> questionRepository, 
            IRepository<Category> categoryRepository, 
            IRepository<Score> scoreRepository)
        {
            _questionRepository = questionRepository;
            _categoryRepository = categoryRepository;
            _scoreRepository = scoreRepository;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryRepository.GetDataAsync();
            
            return View(categories);
        }

        public IActionResult StartGame(Guid categoryId)
        {
            _start = DateTime.Now;

            _index = 1;
            _score = 0;

            return Json(new {redirectToUrl = Url.Action("Question", new {categoryId})});
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
            
            if (!question.HaveAnswers())
            {
                ModelState.AddModelError("", "this question don't have answers");

                return View(question.ToViewModel());
            }

            _index++;

            return View(question.ToViewModel());
        }
        
        public async Task<IActionResult> NextQuestion(Guid categoryId)
        {
            var question = await _questionRepository.FirstAsync(
                x => x.Index == _index && x.CategoryId == categoryId,
                x => x.Include(y => y.PossibleAnswers));

            if (question is null)
            {
                return RedirectToAction(nameof(Score));
            }
            
            if (!question.HaveAnswers())
            {
                ModelState.AddModelError("", "this question don't have answers");

                return View("Question", question.ToViewModel());
            }

            _index++;

            return View("Question", question.ToViewModel());
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

        public async Task<IActionResult> Score()
        {
            _end = DateTime.Now;
            
            var timeDiff = _end.Second - _start.Second;

            var userId = User.Identity.GetId();

            var score = new Score(_score, timeDiff, userId);
            
            _scoreRepository.Add(score);

            await _scoreRepository.SaveAsync();
            
            return View(score);
        }

        public IActionResult Reset()
        {
            _score = 0;
            _index = 1;

            return RedirectToAction(nameof(Index));
        }
        
        [HttpGet]
        public async Task<IActionResult> CountQuestionsOfCategory(Guid categoryId)
        {
            var totalQuestionsOfCategory = await _questionRepository.CountAsync(x => x.CategoryId == categoryId);

            return Ok(new {count = totalQuestionsOfCategory});
        }
    }
}