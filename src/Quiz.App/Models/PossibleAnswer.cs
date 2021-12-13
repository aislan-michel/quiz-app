namespace Quiz.App.Models
{
    public class PossibleAnswer
    {
        public PossibleAnswer(string answer, bool isAnswer)
        {
            Answer = answer;
            IsAnswer = isAnswer;
        }
        
        public string Answer { get; private set; }
        public bool IsAnswer { get; private set; }
    }
}