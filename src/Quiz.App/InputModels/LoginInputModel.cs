using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Quiz.App.InputModels
{
    public class LoginInputModel
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }
    }
}