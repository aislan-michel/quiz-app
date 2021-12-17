using System.Collections.Generic;

namespace Quiz.App.Models
{
    public class User : BaseModel
    {
        protected User() { }
        
        public User(
            string name, string lastName, List<Score> scores,
            string password)
        {
            Name = name;
            LastName = lastName;
            Scores = scores;
            Password = password;
        }
        
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Password { get; private set; }

        private string _login => $"{Name.ToLower()}.{LastName.ToLower()}@game";

        public string Login { get => _login; private set => Login = value; }
        
        public List<Score> Scores { get; private set; }
    }
}