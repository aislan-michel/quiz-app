using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quiz.App.Infrastructure.Notification;
using Quiz.App.Infrastructure.Repositories;
using Quiz.App.Models.InputModels;
using Quiz.App.Models.Mappings;

namespace Quiz.App.Controllers
{
    [Authorize(Roles = "admin")]
    public class UserController : BaseController
    {
        private readonly IIdentityRepository _identityRepository;

        public UserController( 
            IIdentityRepository identityRepository,
            INotificator notificator) : base(notificator)
        {
            _identityRepository = identityRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _identityRepository.GetUsersInRoleCommon());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateUserInputModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }
            
            var entity = inputModel.ToEntity();

            await _identityRepository.Register(entity, inputModel.Password);
            
            if (!Notificator.HaveNotifications())
            {
                return RedirectToAction("Details", new {id = entity.Id});
            }
            
            foreach (var (key, value) in Notificator.Get())
            {
                ModelState.AddModelError(key, value);
            }
                
            return View(inputModel);
        }
        
        public async Task<IActionResult> Details(Guid id)
        {
            return View(await _identityRepository.GetById(id.ToString()));
        }
    }
}