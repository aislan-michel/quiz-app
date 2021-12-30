using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Quiz.App.Extensions;
using Quiz.App.InputModels;
using Quiz.App.Mappings;
using Quiz.App.Models;

namespace Quiz.App.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        
        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> SignIn(LoginInputModel inputModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(inputModel);
                }

                var signInResult = await _signInManager.PasswordSignInAsync(inputModel.Username, inputModel.Password, false, false);

                if (!signInResult.Succeeded)
                {
                    ModelState.AddModelError("invalid", "login or password is invalid");

                    return View(inputModel);
                }
            
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public new async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction(nameof(SignIn));
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }
            
            var user = inputModel.ToModel();

            var created = await _userManager.CreateAsync(user, inputModel.Password);

            if (!created.Succeeded)
            {
                ModelState.AddIdentityErrors(created.Errors);

                return View(inputModel);
            }

            await _userManager.AddToRoleAsync(user, "common");
            
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> GetMyScores(string userId) //preciso criar uma ScoreController?
        {
            var user = await _userManager.FindByIdAsync(userId);
            
            throw new NotImplementedException();
        }
    }
}