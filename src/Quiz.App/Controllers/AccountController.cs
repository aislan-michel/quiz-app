using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiz.App.Infrastructure.Notification;
using Quiz.App.Infrastructure.Repositories;
using Quiz.App.Models.InputModels;
using Quiz.App.Models.Mappings;

namespace Quiz.App.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IIdentityRepository _identityRepository;
        
        public AccountController(IIdentityRepository identityRepository, INotificator notificator) : base(notificator)
        {
            _identityRepository = identityRepository;
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

            await _identityRepository.SignIn(inputModel.Username, inputModel.Password);

            if (!Notificator.HaveNotifications())
            {
                return RedirectToAction("Index", "Home");   
            }
            
            foreach (var (key, value) in Notificator.Get())
            {
                ModelState.AddModelError(key, value);
            }
            
            return View(inputModel);
        }

        public new async Task<IActionResult> SignOut()
        {
            await _identityRepository.SignOut();

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
            
            var entity = inputModel.ToEntity();

            await _identityRepository.Register(entity, inputModel.Password);
            
            if (Notificator.HaveNotifications())
            {
                ModelState.AddModelError(Notificator.Get().FirstOrDefault().Key, Notificator.Get().FirstOrDefault().Value);
                return View(inputModel);
            }

            return RedirectToAction(nameof(SignIn));

        }
    }
}