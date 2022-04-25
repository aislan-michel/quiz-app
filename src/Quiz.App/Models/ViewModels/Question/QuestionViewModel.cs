using System;
using System.Collections.Generic;

namespace Quiz.App.Models.ViewModels.Question;

public class QuestionViewModel
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public int Index { get; set; }
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; }
    public IEnumerable<PossibleAnswersViewModel> PossibleAnswers { get; set; }
    public int CountAnswers { get; set; }
    public bool HaveAnswers { get; set; }
}