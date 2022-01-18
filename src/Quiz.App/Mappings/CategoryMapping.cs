using System.Collections.Generic;
using System.Linq;
using Quiz.App.Models.InputModels;
using Quiz.App.Models.Entities;
using Quiz.App.Models.ViewModels.Category;
using Quiz.App.Models.ViewModels;

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
                (
                    x.Name,
                    x.Questions.Count
                )) 
            };
        }

        public static IEnumerable<CategoryViewModel> ToQuizCategoryViewModel(this IEnumerable<Category> categories)
        {
            return categories.Select(x => new CategoryViewModel
            (
                x.Id,
                x.Name,
                x.HaveQuestions()
            ));
        }
    }
}