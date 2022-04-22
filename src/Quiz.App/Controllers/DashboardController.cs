using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quiz.App.Extensions;
using Quiz.App.Infrastructure.Repositories;
using Quiz.App.Models.Entities;

namespace Quiz.App.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IRepository<Score> _scoreRepository;

        public DashboardController(IRepository<Score> scoreRepository)
        {
            _scoreRepository = scoreRepository;
        }
        
        public async Task<IActionResult> Index()
        {
            var userId = User.Identity.GetId();

            var scores = await _scoreRepository.GetDataAsync(
                x => x.UserId == userId,
                x => x.Include(y => y.Category)); 
            
            return View(scores);
        }
    }
}