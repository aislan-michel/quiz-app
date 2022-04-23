using Quiz.App.InputModels;
using Quiz.App.Models.Entities;

namespace Quiz.App.Mappings
{
    public static class QuestionMapping
    {
        public static Question ToModel(this CreateQuestionInputModel inputModel)
        {
            return new(
                inputModel.Text, inputModel.Index, inputModel.CategoryId);
        }
    }
}