using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Quiz.App.Extensions;
using Quiz.App.Models.InputModels;
using Quiz.App.Models;
using Quiz.App.Models.Entities;
using Quiz.App.Models.Mappings;

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
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }

            var user = await _userManager.FindByNameAsync(inputModel.Username);

            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Sid, user.Id));

            var signInResult = await _signInManager.PasswordSignInAsync(inputModel.Username, inputModel.Password, false, false);

            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("invalid", "login or password is invalid");

                return View(inputModel);
            }
            
            return RedirectToAction("Index", "Home");
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

            await _userManager.AddToRoleAsync(user, Roles.Common);
            
            return RedirectToAction(nameof(SignIn));
        }
    }
}