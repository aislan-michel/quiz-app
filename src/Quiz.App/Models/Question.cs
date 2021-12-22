using System;
using System.Collections.Generic;
using System.Linq;

namespace Quiz.App.Models
{
    public class Question : BaseModel
    {
        protected Question() { }
        
        public Question(string text, List<PossibleAnswer> possibleAnswers, int index, Guid categoryId) : base()
        {
            Text = text;
            PossibleAnswers = possibleAnswers;
            Index = index;
            CategoryId = categoryId;
        }

        public string Text { get; private set; }
        public IReadOnlyCollection<PossibleAnswer> PossibleAnswers { get; }
        public int Index { get; private set; }
        public Guid CategoryId { get; private set; }
        public Category Category { get; private set; }
        
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
            return PossibleAnswers != null && PossibleAnswers.Any();
        }

        public int CountAnswers()
        {
            return !HaveAnswers() ? 0 : PossibleAnswers.Count;
        }

        public void Update(string text, int index, Guid categoryId)
        {
            Text = text;
            Index = index;
            CategoryId = categoryId;
        }
    }
}