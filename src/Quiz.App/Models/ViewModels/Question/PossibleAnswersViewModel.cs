using System;

namespace Quiz.App.Models.ViewModels.Question;

public class PossibleAnswersViewModel
{
    public Guid Id { get; set; }
    public bool IsAnswer { get; set; }
    public string Text { get; set; }
}