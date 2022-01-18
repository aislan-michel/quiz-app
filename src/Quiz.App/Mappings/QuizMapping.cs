using System.Collections.Generic;
using System.Linq;
using Quiz.App.Models.Entities;
using Quiz.App.Models.ViewModels;

namespace Quiz.App.Mappings
{
    public static class QuizMapping
    {
        public static QuestionViewModel ToViewModel(this Question question)
        {
            return new
            (
                question.Id,
                question.Text,
                question.Index,
                question.CategoryId,
                question.Category.Name,
                question.PossibleAnswers.ToViewModel()
            );
        }

        private static IEnumerable<PossibleAnswerViewModel> ToViewModel(this IEnumerable<PossibleAnswer> possibleAnswer)
        {
            return possibleAnswer.Select(x => new PossibleAnswerViewModel
            (
                x.Answer
            ));
        }
    }
}