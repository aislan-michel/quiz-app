using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quiz.App.Models
{
    public class User : BaseModel
    {
        private readonly IList<Score> _scores;
        
        protected User() { }
        
        public User(
            string firstName, string lastName,
            string password, string role)
        {
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Login = GenerateLogin();
            Role = role;
            _scores = new List<Score>();
        }
        
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Password { get; private set; }
        public string Login { get; private set; }
        public string Role { get; private set; }

        public IReadOnlyCollection<Score> Scores => _scores.ToArray();

        private string GenerateLogin()
        {
            const string whiteSpace = " ";
            const char dot = '.';

            var login = new StringBuilder();

            login
                .Append(FirstName.Contains(whiteSpace) ? FirstName.Split(whiteSpace)[0] : FirstName)
                .Append(dot)
                .Append(LastName.Contains(whiteSpace) ? LastName.Split(whiteSpace)[0] : LastName)
                .Append("@game");

            return login.ToString();
        }
        
    }
}