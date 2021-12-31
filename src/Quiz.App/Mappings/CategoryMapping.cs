using System.Collections.Generic;
using System.Linq;
using Quiz.App.InputModels;
using Quiz.App.Models;
using Quiz.App.ViewModels;

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
    }
}