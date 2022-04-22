using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quiz.App.Extensions;
using Quiz.App.Infrastructure.Repositories;
using Quiz.App.InputModels;
using Quiz.App.Mappings;
using Quiz.App.Models.Entities;

namespace Quiz.App.Controllers
{
    [Authorize]
    public class QuizController : Controller
    {
        private static int _correctAnswers;
        private static int _index = 1;
        private static int _questionsCount;
        private readonly IRepository<Question> _questionRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Score> _scoreRepository;
        private readonly ICacheRepository<DateTime> _startDateCache;

        public QuizController(
            IRepository<Question> questionRepository, 
            IRepository<Category> categoryRepository, 
            IRepository<Score> scoreRepository, 
            ICacheRepository<DateTime> startDateCache)
        {
            _questionRepository = questionRepository;
            _categoryRepository = categoryRepository;
            _scoreRepository = scoreRepository;
            _startDateCache = startDateCache;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryRepository.GetDataAsync(
                include: x => x.Include(y => y.Questions));

            return View(categories.ToIndexViewModel());
        }

        public async Task<IActionResult> StartGame(Guid categoryId)
        {
            var startDate = DateTime.Now;
            
            var userId = User.Identity.GetId();
            
            _startDateCache.Set(userId, startDate);

            _index = 1;
            _correctAnswers = 0;
            _questionsCount = await _questionRepository.CountAsync(x => x.CategoryId == categoryId);

            return RedirectToAction("Question", new {categoryId});
        }

        public async Task<IActionResult> Question(Guid categoryId)
        {
            var question = await _questionRepository.FirstAsync(
                x => x.Index == _index && x.CategoryId == categoryId,
                x => x.Include(y => y.PossibleAnswers));

            if (question is null)
            {
                return RedirectToAction(nameof(Score), new {categoryId});
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
                return RedirectToAction(nameof(Score), new {categoryId});
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
                _correctAnswers++;
            }

            return RedirectToAction("Question", new{ categoryId = inputModel.CategoryId.ToString() });
        }

        public async Task<IActionResult> Score(Guid categoryId)
        {
            var endDate = DateTime.Now;
            
            var userId = User.Identity.GetId();

            var startDate = _startDateCache.Get(userId);
            
            var timeDiff = endDate.Second - startDate.Second;
 
            var score = new Score(userId, categoryId, _questionsCount, _correctAnswers, timeDiff);
            
            _scoreRepository.Add(score);

            await _scoreRepository.SaveAsync();
            
            return View(score);
        }

        public IActionResult Reset()
        {
            _correctAnswers = 0;
            _index = 1;

            return RedirectToAction(nameof(Index));
        }
    }
}