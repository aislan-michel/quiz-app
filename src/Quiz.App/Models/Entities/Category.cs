using System.Collections.Generic;
using System.Linq;

namespace Quiz.App.Models.Entities
{
    public class Category : BaseEntity
    {
        private IList<Question> _questions;
        private IList<Score> _scores;
        
        protected Category() { }
        
        public Category(string name)
        {
            Name = name;
            _questions = new List<Question>();
            _scores = new List<Score>();
        }
        
        public string Name { get; private set; }
        public IReadOnlyCollection<Question> Questions => _questions.ToArray();
        public IReadOnlyCollection<Score> Scores => _scores.ToArray();

        public bool HaveQuestions()
        {
            if (Questions == null)
            {
                return false;
            }

            if (!Questions.Any())
            {
                return false;
            }

            return true;
        }
    }
}