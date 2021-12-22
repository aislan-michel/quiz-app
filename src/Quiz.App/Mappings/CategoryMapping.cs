using System.Collections.Generic;
using Quiz.App.InputModels;
using Quiz.App.Models;

namespace Quiz.App.Mappings
{
    public static class CategoryMapping
    {
        public static Category ToModel(this CreateCategoryInputModel inputModel)
        {
            return new Category(inputModel.Name, new List<Question>());
        }
    }
}