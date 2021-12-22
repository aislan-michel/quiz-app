using System.Collections.Generic;
using Quiz.App.InputModels;
using Quiz.App.Models;

namespace Quiz.App.Mappings
{
    public static class QuestionMapping
    {
        public static Question ToModel(this CreateQuestionInputModel inputModel)
        {
            return new(
                inputModel.Text, new List<PossibleAnswer>(4), inputModel.Index, inputModel.CategoryId);
        }
    }
}