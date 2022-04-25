namespace Quiz.App.Models.InputModels
{
    public class CreateUserInputModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}