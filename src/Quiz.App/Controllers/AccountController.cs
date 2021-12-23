using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiz.App.Infrastructure.Repositories;
using Quiz.App.InputModels;
using Quiz.App.Models;
using Quiz.App.Services;

namespace Quiz.App.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRepository<User> _repository;
        private readonly ITokenService _tokenService;

        public AccountController(IRepository<User> repository, ITokenService tokenService)
        {
            _repository = repository;
            _tokenService = tokenService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(LoginInputModel inputModel)
        {
            var user = await _repository.FirstAsync(x => x.Login == inputModel.Login);

            if (user is null)
                return BadRequest(new {message = "Usuário ou senha inválidos"});

            var token = _tokenService.GenerateToken(user);

            return RedirectToAction("Index", "Home");
        }
    }
}