using System.ComponentModel.DataAnnotations;

namespace Quiz.App.InputModels
{
    public class CreateCategoryInputModel
    {
        [Required]
        public string Name { get; set; }
    }
}