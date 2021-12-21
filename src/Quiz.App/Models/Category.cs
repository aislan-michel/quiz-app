using System.Collections.Generic;

namespace Quiz.App.Models
{
    public class Category : BaseModel
    {
        protected Category() { }
        
        public Category(string name, List<Question> questions)
        {
            Name = name;
            Questions = questions;
        }
        
        public string Name { get; private set; }
        public List<Question> Questions { get; private set; }
    }
}