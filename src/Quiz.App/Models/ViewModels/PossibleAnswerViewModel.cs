namespace Quiz.App.Models.ViewModels
{
    public class PossibleAnswerViewModel
    {
        public PossibleAnswerViewModel(bool isAnswer, string text)
        {
            IsAnswer = isAnswer;
            Text = text;
        }

        public PossibleAnswerViewModel(string text)
        {
            Text = text;
        }
        
        public bool IsAnswer { get; set; }
        public string Text { get; set; }
    }
}