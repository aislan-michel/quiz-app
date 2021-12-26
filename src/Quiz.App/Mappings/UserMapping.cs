using Quiz.App.InputModels;
using Quiz.App.Models;

namespace Quiz.App.Mappings
{
    public static class UserMapping
    {
        public static User ToModel(this CreateUserInputModel inputModel)
        {
            return new(inputModel.FirstName, inputModel.LastName, inputModel.Password,
                inputModel.Role);
        }

        public static User ToModel(this RegisterUserInputModel inputModel)
        {
            return new(inputModel.FirstName, inputModel.LastName, inputModel.Password, "default");
        }
    }
}