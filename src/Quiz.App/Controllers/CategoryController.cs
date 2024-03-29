﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Quiz.App.Infrastructure.Repositories;
using Quiz.App.Models.InputModels;
using Quiz.App.Models.Entities;
using Quiz.App.Models.Mappings;

namespace Quiz.App.Controllers
{
    [Authorize(Roles = "admin")]
    public class CategoryController : Controller
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryController(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryRepository.GetDataAsync(
                include: x => x.Include(y => y.Questions));
            
            return View(categories.ToViewModel());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }
            
            var entity = inputModel.ToEntity();
            
            _categoryRepository.Add(entity);

            await _categoryRepository.SaveAsync();

            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public async Task<IActionResult> Get(Guid? id)
        {
            var categories = await _categoryRepository.GetDataAsync();

            var selectList = new SelectList(
                categories.AsEnumerable(), 
                "Id", 
                "Name", 
                id.HasValue ? categories.First(x => x.Id == id).Id.ToString() : null);
            
            return Json(selectList);
        }
    }
}