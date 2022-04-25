using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quiz.App.Extensions;
using Quiz.App.Infrastructure.Repositories;
using Quiz.App.Models.InputModels;
using Quiz.App.Models.Entities;
using Quiz.App.Models.Mappings;

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

            return View(categories.ToQuizViewModel());
        }

        public async Task<IActionResult> StartGame(Guid categoryId)
        {
            var startDate = DateTime.Now;
            
            var userId = User.Identity.GetId();
            
            _startDateCache.Set(userId, startDate);

            ResetGame();
            
            _questionsCount = await _questionRepository.CountAsync(x => x.CategoryId == categoryId);

            return RedirectToAction(nameof(Question), new {categoryId});
        }

        public async Task<IActionResult> Question(Guid categoryId)
        {
            var question = await _questionRepository.FirstAsync(
                            expression: x => x.CategoryId == categoryId,
                            include: x => x
                                            .Include(y => y.PossibleAnswers)
                                            .Include(y => y.Category),
                            skip: _index);

            if (question is null)
            {
                return RedirectToAction(nameof(Score), new {categoryId});
            }
            
            if (!question.HaveAnswers())
            {
                ModelState.AddModelError("", "this question don't have answers");

                return View(question.ToQuizViewModel());
            }

            _index++;

            return View(question.ToQuizViewModel());
        }
        
        public async Task<IActionResult> NextQuestion(Guid categoryId)
        {
            var question = await _questionRepository.FirstAsync(
                x => x.CategoryId == categoryId,
                x => x.Include(y => y.PossibleAnswers),
                skip: _index);

            if (question is null)
            {
                return RedirectToAction(nameof(Score), new {categoryId});
            }
            
            if (!question.HaveAnswers())
            {
                ModelState.AddModelError("", "this question don't have answers");

                return View(nameof(Question), question.ToQuizViewModel());
            }

            _index++;

            return View(nameof(Question), question.ToQuizViewModel());
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

            return RedirectToAction(nameof(Question), new{ categoryId = inputModel.CategoryId.ToString() });
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
            
            return View(score.ToQuizViewModel());
        }

        public IActionResult Reset()
        {
            ResetGame();

            return RedirectToAction(nameof(Index));
        }

        private static void ResetGame()
        {
            _correctAnswers = 0;
            _index = 0;
        }
    }
}