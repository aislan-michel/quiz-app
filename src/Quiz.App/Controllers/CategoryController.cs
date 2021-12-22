using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        [HttpGet("category/get")]
        public async Task<IActionResult> Get()
        {
            return Json(await _categoryRepository.GetDataAsync());
        }
        
        [HttpGet("category/get/{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var categories = await _categoryRepository.GetDataAsync();

            var selectedCategory = categories.First(x => x.Id == id);

            var selectList = new SelectList(categories.AsEnumerable(), "Id", "Name", selectedCategory.Id.ToString());
            
            return Json(selectList);
        }
    }
}