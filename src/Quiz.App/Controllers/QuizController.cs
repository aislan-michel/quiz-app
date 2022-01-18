using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quiz.App.Extensions;
using Quiz.App.Infrastructure.Repositories;
using Quiz.App.Models.InputModels;
using Quiz.App.Mappings;
using Quiz.App.Models.Entities;
using Quiz.App.Models.ViewModels;

namespace Quiz.App.Controllers
{
    [Authorize]
    public class QuizController : Controller
    {
        private static int _correctAnswers;
        private static int _currentQuestion = 1;
        private static int _questionsCount;
        private readonly IRepository<Question> _questionRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Score> _scoreRepository;
        private readonly ICacheRepository<DateTime> _startTimeCache;

        public QuizController(
            IRepository<Question> questionRepository, 
            IRepository<Category> categoryRepository, 
            IRepository<Score> scoreRepository, 
            ICacheRepository<DateTime> startTimeCache)
        {
            _questionRepository = questionRepository;
            _categoryRepository = categoryRepository;
            _scoreRepository = scoreRepository;
            _startTimeCache = startTimeCache;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryRepository.GetDataAsync(
                include: x => x.Include(y => y.Questions));

            return View(new QuizIndexViewModel() {Categories = categories.ToCategoryViewModel()});
        }

        public async Task<IActionResult> StartGame(Guid categoryId)
        {
            await SetupGame(categoryId);
            
            StartTime();

            return RedirectToAction("Question", new {categoryId});
        }
        
        private async Task SetupGame(Guid categoryId)
        {
            _currentQuestion = 1;
            _correctAnswers = 0;
            _questionsCount = await _questionRepository.CountAsync(x => x.CategoryId == categoryId);
        }

        private void StartTime()
        {
            var startDate = DateTime.Now;
            
            var userId = User.Identity.GetId();
            
            _startTimeCache.Set(userId, startDate);
        }

        public async Task<IActionResult> Question(Guid categoryId)
        {
            var question = await _questionRepository.FirstAsync(
                x => x.Index == _currentQuestion && x.CategoryId == categoryId,
                x => x
                    .Include(y => y.PossibleAnswers)
                    .Include(y => y.Category));

            if (question is null)
            {
                return RedirectToAction(nameof(Score), new {categoryId});
            }
            
            if (!question.HaveAnswers())
            {
                ModelState.AddModelError("question", "this question don't have answers");

                return View(question.ToViewModel());
            }

            _currentQuestion++;

            return View(question.ToViewModel());
        }
        
        public async Task<IActionResult> NextQuestion(Guid categoryId)
        {
            var question = await _questionRepository.FirstAsync(
                x => x.Index == _currentQuestion && x.CategoryId == categoryId,
                x =>
                {
                    return x
                        .Include(y => y.PossibleAnswers)
                        .Include(y => y.Category);
                    
                });

            if (question is null)
            {
                return RedirectToAction(nameof(Score), new {categoryId});
            }
            
            if (!question.HaveAnswers())
            {
                ModelState.AddModelError("question", "this question don't have answers");

                return View("Question", question.ToViewModel());
            }

            _currentQuestion++;

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

            var startDate = _startTimeCache.Get(userId);
            
            var timeToFinish = endDate.Second - startDate.Second;
 
            var score = new Score(userId, categoryId, _questionsCount, _correctAnswers, timeToFinish);
            
            _scoreRepository.Add(score);

            await _scoreRepository.SaveAsync();
            
            _startTimeCache.Remove(userId);
            
            return View(score.ToQuizScoreViewModel());
        }
        
        public IActionResult Reset()
        {
            return RedirectToAction(nameof(Index));
        }
    }
}