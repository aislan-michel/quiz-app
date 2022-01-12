using System;
using System.Collections.Generic;

namespace Quiz.App.Models.ViewModels.Quiz
{
    public class QuestionViewModel
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public int Index { get; set; }
        public string Text { get; set; }
        public IEnumerable<PossibleAnswerViewModel> PossibleAnswers { get; set; }
    }
}