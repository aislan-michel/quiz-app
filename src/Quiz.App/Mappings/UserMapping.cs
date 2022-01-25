using System.Collections.Generic;
using System.Linq;
using Quiz.App.Models.InputModels;
using Quiz.App.Models.Entities;
using Quiz.App.Models.ViewModels;

namespace Quiz.App.Mappings
{
    public static class UserMapping
    {
        public static User ToModel(this CreateUserInputModel inputModel)
        {
            return new(inputModel.FirstName, inputModel.LastName);
        }

        public static User ToModel(this RegisterUserInputModel inputModel)
        {
            return new(inputModel.FirstName, inputModel.LastName);
        }

        public static UserIndexViewModel ToIndexViewModel(this IEnumerable<User> users)
        {
            return new(users.Select(x => new UserViewModel(x.Id, x.FullName(), x.Email, "")));
        }
    }
}