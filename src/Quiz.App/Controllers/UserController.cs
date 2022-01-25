using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Quiz.App.Infrastructure.Security;
using Quiz.App.Models.InputModels;
using Quiz.App.Mappings;
using Quiz.App.Models.Entities;

namespace Quiz.App.Controllers
{
    [Authorize(Roles = "admin")]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;

        public UserController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.GetUsersInRoleAsync(Role.Common);
            
            return View(users.ToIndexViewModel());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }
            
            var user = inputModel.ToModel();

            await _userManager.CreateAsync(user);
            
            return RedirectToAction("Index");
        }
    }
}