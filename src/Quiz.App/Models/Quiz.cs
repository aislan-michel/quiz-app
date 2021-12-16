using System.Collections.Generic;

namespace Quiz.App.Models
{
    public class Quiz : BaseModel
    {
        protected Quiz() { }    

        public Quiz(string name, List<Question> questions)
        {
            Name = name;
            Questions = questions;
        }
        
        public string Name { get; private set; }
        public List<Question> Questions { get; private set; }
    }
}