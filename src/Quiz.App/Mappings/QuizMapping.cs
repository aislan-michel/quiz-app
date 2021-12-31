using System.Collections.Generic;
using System.Linq;
using Quiz.App.Models;
using Quiz.App.ViewModels.Quiz;

namespace Quiz.App.Mappings
{
    public static class QuizMapping
    {
        public static QuestionViewModel ToViewModel(this Question question)
        {
            return new()
            {
                Id = question.Id,
                CategoryId = question.CategoryId,
                Index = question.Index,
                Text = question.Text,
                PossibleAnswers = question.PossibleAnswers.ToViewModel()
            };
        }

        private static IEnumerable<PossibleAnswerViewModel> ToViewModel(this IEnumerable<PossibleAnswer> possibleAnswer)
        {
            return possibleAnswer.Select(x => new PossibleAnswerViewModel
            {
                Answer = x.Answer
            });
        }
    }
}