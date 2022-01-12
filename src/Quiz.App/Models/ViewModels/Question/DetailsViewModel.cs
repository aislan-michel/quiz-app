using System.Collections.Generic;

namespace Quiz.App.ViewModels.Question
{
    public class DetailsViewModel
    {
        public int AnswersCount { get; set; }
        public bool HaveAnswers { get; set; }
        public QuestionViewModel Question { get; set; }
        public IEnumerable<PossibleAnswerViewModel> PossibleAnswers  { get; set; }
    }
}