using System.Collections.Generic;
using System.Linq;
using Quiz.App.Models.InputModels;
using Quiz.App.Models.Entities;
using Quiz.App.Models.ViewModels.Category;

namespace Quiz.App.Mappings
{
    public static class CategoryMapping
    {
        public static Category ToModel(this CreateCategoryInputModel inputModel)
        {
            return new(inputModel.Name);
        }

        public static IndexViewModel ToCategoryIndexViewModel(this IEnumerable<Category> categories)
        {
            return new()
            {
                Categories = categories.Select(x => new CategoryViewModel
                {
                    Name = x.Name,
                    TotalQuestions = x.Questions.Count
                }) 
            };
        }

        public static IEnumerable<Models.ViewModels.Quiz.CategoryViewModel> ToQuizCategoryViewModel(this IEnumerable<Category> categories)
        {
            return categories.Select(x => new Models.ViewModels.Quiz.CategoryViewModel
            {
                CategoryId = x.Id,
                CategoryName = x.Name,
                CategoryHaveQuestions = x.HaveQuestions()
            });
        }
    }
}