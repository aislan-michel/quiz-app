using System;

namespace Quiz.App.Models.ViewModels;

public class PossibleAnswersViewModel
{
    public Guid Id { get; set; }
    public bool IsAnswer { get; set; }
    public string Text { get; set; }
}