using System.Linq;
using Quiz.App.Models.InputModels;
using Quiz.App.Models.Entities;
using Quiz.App.ViewModels.Question;

namespace Quiz.App.Mappings
{
    public static class QuestionMapping
    {
        public static Question ToModel(this CreateQuestionInputModel inputModel)
        {
            return new(
                inputModel.Text, inputModel.Index, inputModel.CategoryId);
        }

        public static DetailsViewModel ToDetailsViewModel(this Question question)
        {
            return new()
            {
                AnswersCount = question.CountAnswers(),
                HaveAnswers = question.HaveAnswers(),
                Question = new QuestionViewModel
                {
                    Id = question.Id,
                    Text = question.Text,
                    Index = question.Index,
                    CategoryName = question.Category.Name
                },
                PossibleAnswers = question.PossibleAnswers.Select(x => new PossibleAnswerViewModel
                {
                    IsAnswer = x.IsAnswer,
                    Text = x.Answer
                })
            };
        }
    }
}