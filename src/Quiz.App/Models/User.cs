using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Quiz.App.Extensions;

namespace Quiz.App.Models
{
    public class User : IdentityUser
    {
        private readonly IList<Score> _scores;

        protected User() { }
        
        public User(
            string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = GenerateUserName();
            _scores = new List<Score>();
        }
        
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public IReadOnlyCollection<Score> Scores => _scores.ToArray();

        private string GenerateUserName()
        {
            const char dot = '.';

            var userName = new StringBuilder();

            userName
                .Append(FirstName.ContainsWhiteSpace() ? FirstName.GetFirstWord() : FirstName)
                .Append(dot)
                .Append(LastName.ContainsWhiteSpace() ? LastName.GetLastWord() : LastName)
                .Append("@game");

            return userName.ToString().ToLower();
        }
    }
}