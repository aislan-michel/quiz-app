using System;

namespace Quiz.App.Models
{
    public class PossibleAnswer : BaseModel
    {
        protected PossibleAnswer() { }
        
        public PossibleAnswer(string answer, bool isAnswer, Guid questionId)
        {
            Answer = answer;
            IsAnswer = isAnswer;
            QuestionId = questionId;
        }
        
        public string Answer { get; }
        public bool IsAnswer { get; }
        public Guid QuestionId { get; private set; }
        public Question Question { get; private set; }
    }
}