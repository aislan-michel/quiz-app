using System.Collections.Generic;

namespace Quiz.App.Models
{
    public class User : BaseModel
    {
        protected User() { }
        
        public User(string name, string lastName, List<Score> scores)
        {
            Name = name;
            LastName = lastName;
            Scores = scores;
        }
        
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public List<Score> Scores { get; private set; }
    }
}