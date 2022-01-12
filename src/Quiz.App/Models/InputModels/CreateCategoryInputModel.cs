using System.ComponentModel.DataAnnotations;

namespace Quiz.App.Models.InputModels
{
    public class CreateCategoryInputModel
    {
        [Required]
        public string Name { get; set; }
    }
}