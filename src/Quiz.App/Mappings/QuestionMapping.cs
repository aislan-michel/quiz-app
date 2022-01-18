using System.Collections.Generic;
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

        public static QuestionIndexViewModel ToQuestionIndexViewModel(this IEnumerable<Question> questions)
        {
            return new(
                questions.Select(x => new QuestionViewModel(x.Id, x.Text, x.Index, x.Category.Name)));
        }

        public static QuestionViewModel ToSimulateQuestionViewModel(this Question question)
        {
            return new(question.Id, question.CategoryId, question.Text,
                question.PossibleAnswers.Select(x => new PossibleAnswerViewModel(x.Id, x.Answer)));
        }
    }
}