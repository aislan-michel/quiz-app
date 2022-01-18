using System;

namespace Quiz.App.Models.ViewModels
{
    public class PossibleAnswerViewModel
    {
        public PossibleAnswerViewModel(Guid id, string text)
        {
            Id = id;
            Text = text;
        }
        
        public PossibleAnswerViewModel(bool isAnswer, string text)
        {
            IsAnswer = isAnswer;
            Text = text;
        }

        public PossibleAnswerViewModel(string text)
        {
            Text = text;
        }

        public Guid Id { get; set; }
        public bool IsAnswer { get; set; }
        public string Text { get; set; }
    }
}