using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Quiz.App.InputModels
{
    public class RegisterUserInputModel
    {
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }
    }
}