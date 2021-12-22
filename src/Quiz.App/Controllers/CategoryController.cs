using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiz.App.Infrastructure.Repositories;
using Quiz.App.InputModels;
using Quiz.App.Mappings;
using Quiz.App.Models;

namespace Quiz.App.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryController(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _categoryRepository.GetDataAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryInputModel inputModel)
        {
            var model = inputModel.ToModel();
            
            _categoryRepository.Add(model);

            await _categoryRepository.SaveAsync();

            return RedirectToAction("Index");
        }
    }
}