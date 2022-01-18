using System.Linq;
using Quiz.App.Models.InputModels;
using Quiz.App.Models.Entities;
using Quiz.App.Models.ViewModels;

namespace Quiz.App.Mappings
{
    public static class QuestionMapping
    {
        public static Question ToModel(this CreateQuestionInputModel inputModel)
        {
            return new(
                inputModel.Text, inputModel.Index, inputModel.CategoryId);
        }

        public static QuestionDetailsViewModel ToQuestionDetailsViewModel(this Question question)
        {
            return new()
            {
                AnswersCount = question.CountAnswers(),
                HaveAnswers = question.HaveAnswers(),
                Question = new QuestionViewModel
                (
                    question.Id,
                    question.Text,
                    question.Index,
                    question.Category.Name
                ),
                PossibleAnswers = question.PossibleAnswers.Select(x => new PossibleAnswerViewModel
                (
                    x.IsAnswer,
                    x.Answer
                ))
            };
        }
    }
}