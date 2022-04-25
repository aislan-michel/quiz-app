using System;

namespace Quiz.App.Models.ViewModels;

public class ScoreViewModel
{
    public Guid Id { get; set; }
    public string CategoryName { get; set; }
    public int QuestionsCount { get; set; }
    public int CorrectQuestionsCount { get; set; }
    public int IncorrectQuestionsCount { get; set; }
    public int SecondsToFinish { get; set; }
    public bool Approved { get; set; }
}