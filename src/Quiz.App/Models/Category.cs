using System.Collections.Generic;
using System.Linq;

namespace Quiz.App.Models
{
    public class Category : BaseModel
    {
        protected Category() { }
        
        public Category(string name)
        {
            Name = name;
            Questions = new List<Question>();
        }
        
        public string Name { get; private set; }
        public IReadOnlyCollection<Question> Questions { get; private set; }

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