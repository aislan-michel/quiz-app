using System;
using System.Collections.Generic;
using System.Linq;

namespace Quiz.App.Models.Entities
{
    public class Question : BaseEntity
    {
        protected Question() { }
        
        public Question(string text, int index, Guid categoryId) : base()
        {
            Text = text;
            PossibleAnswers = new List<PossibleAnswer>();
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
            return GetCorrectAnswer().Answer == answer;
        }

        public bool IsCorrectAnswer(Guid answerId)
        {
            return GetCorrectAnswer().Id == answerId;
        }

        public PossibleAnswer GetCorrectAnswer()
        {
            return PossibleAnswers.FirstOrDefault(x => x.IsAnswer);
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