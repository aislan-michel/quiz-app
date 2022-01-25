namespace Quiz.App.Models.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(string id, string fullName, string email, string role)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            Role = role;
        }

        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}