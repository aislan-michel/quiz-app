using System;
using System.Collections.Generic;
using System.Linq;

namespace Quiz.App.Models
{
    public class Question : BaseModel
    {
        protected Question() { }
        
        public Question(string text, List<PossibleAnswer> possibleAnswers, int index) : base()
        {
            Text = text;
            PossibleAnswers = possibleAnswers;
            Index = index;
        }

        public string Text { get; }
        public List<PossibleAnswer> PossibleAnswers { get; }
        public int Index { get; }
        public Guid QuizId { get; private set; }
        public Quiz Quiz { get; private set; }
        
        public bool IsCorrectAnswer(string answer)
        {
            return GetCorrectAnswer() == answer;
        }

        private string GetCorrectAnswer()
        {
            return PossibleAnswers.FirstOrDefault(x => x.IsAnswer)?.Answer;
        }
    }
}