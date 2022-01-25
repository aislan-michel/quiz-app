using System.Collections.Generic;

namespace Quiz.App.Models.ViewModels
{
    public class UserIndexViewModel
    {
        public UserIndexViewModel(IEnumerable<UserViewModel> users)
        {
            Users = users;
        }
        
        public IEnumerable<UserViewModel> Users { get; set; }
    }
}