using System.Collections.Generic;
using System.Linq;
using Quiz.App.Models.InputModels;
using Quiz.App.Models.Entities;
using Quiz.App.ViewModels;
using Quiz.App.ViewModels.Quiz;

namespace Quiz.App.Mappings
{
    public static class CategoryMapping
    {
        public static Category ToModel(this CreateCategoryInputModel inputModel)
        {
            return new(inputModel.Name);
        }

        public static IEnumerable<CategoriesViewModel> ToViewModel(this IEnumerable<Category> categories)
        {
            return categories.Select(x => new CategoriesViewModel
            {
                Name = x.Name,
                TotalQuestions = x.Questions.Count
            });
        }

        public static IEnumerable<CategoryViewModel> ToQuizViewModel(this IEnumerable<Category> categories)
        {
            return categories.Select(x => new CategoryViewModel()
            {
                CategoryId = x.Id,
                CategoryName = x.Name,
                CategoryHaveQuestions = x.HaveQuestions()
            });
        }
    }
}