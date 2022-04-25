using System.Collections.Generic;
using System.Linq;
using Quiz.App.Models.InputModels;
using Quiz.App.Models.Entities;
using Quiz.App.Models.ViewModels;

namespace Quiz.App.Models.Mappings
{
    public static class CategoryMapping
    {
        public static Category ToModel(this CreateCategoryInputModel inputModel)
        {
            return new Category(inputModel.Name);
        }

        public static IEnumerable<CategoryViewModel> ToViewModel(this IEnumerable<Category> categories)
        {
            return categories.Select(x => new CategoryViewModel
            {
                            Name = x.Name,
                            TotalQuestions = x.Questions.Count
            });
        }
        
        public static IEnumerable<CategoryViewModel> ToQuizViewModel(this IEnumerable<Category> categories)
        {
            return categories.Select(x => new CategoryViewModel()
            {
                            Id = x.Id,
                            Name = x.Name,
                            HaveQuestions = x.HaveQuestions()
            });
        }
    }
}