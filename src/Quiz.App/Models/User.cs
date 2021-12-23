using System.Collections.Generic;

namespace Quiz.App.Models
{
    public class User : BaseModel
    {
        protected User() { }
        
        public User(
            string firstName, string lastName,
            string password, string role)
        {
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Login = $"{FirstName.ToLower().Replace(" ", ".")}.{LastName.ToLower().Replace(" ", ".")}@game";
            Role = role;
            Scores = new List<Score>();
        }
        
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Password { get; private set; }
        public string Login { get; private set; }
        public string Role { get; private set; }
        
        public List<Score> Scores { get; private set; }
    }
}