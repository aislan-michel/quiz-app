using System.Collections.Generic;
using System.Linq;

namespace Quiz.App.Models
{
    public class Question
    {
        public Question(string text, List<PossibleAnswer> possibleAnswers)
        {
            Text = text;
            PossibleAnswers = possibleAnswers;
        }

        public string Text { get; private set; }
        public List<PossibleAnswer> PossibleAnswers { get; private set; }
        public string SelectedAnswer { get; private set; }

        public string GetCorrectAnswer()
        {
            return PossibleAnswers.FirstOrDefault(x => x.IsAnswer)?.Answer;
        }
    }
}