using Quiz.App.Models.InputModels;
using Quiz.App.Models.Entities;

namespace Quiz.App.Models.Mappings
{
    public static class UserMapping
    {
        public static User ToModel(this CreateUserInputModel inputModel)
        {
            return new(inputModel.FirstName, inputModel.LastName);
        }

        public static User ToModel(this RegisterUserInputModel inputModel)
        {
            return new(inputModel.FirstName, inputModel.LastName, inputModel.UserName);
        }
    }
}