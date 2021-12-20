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
        
        public bool IsCorrectAnswer(string answer)
        {
            return GetCorrectAnswer() == answer;
        }

        private string GetCorrectAnswer()
        {
            return PossibleAnswers.FirstOrDefault(x => x.IsAnswer)?.Answer;
        }

        public bool HaveAnswers()
        {
            if (PossibleAnswers == null)
            {
                return false;
            }

            if (!PossibleAnswers.Any())
            {
                return false;
            }

            return true;
        }

        public int CountAnswers()
        {
            if (!HaveAnswers())
            {
                return 0;
            }

            return PossibleAnswers.Count;
        }
    }
}