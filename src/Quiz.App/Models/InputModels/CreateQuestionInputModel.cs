using System;
using System.ComponentModel.DataAnnotations;

namespace Quiz.App.Models.InputModels
{
    public class CreateQuestionInputModel
    {
        [Required]
        public string Text { get; set; } = string.Empty;

        [Required] [Range(1, 15)] 
        public int Index { get; set; } = 1;
        
        [Required]
        [GuidValidation]
        public Guid CategoryId { get; set; } = Guid.Empty;
    }

    public class GuidValidation : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null || value is not Guid)
            {
                return false;
            }
            
            if ((Guid)value == Guid.Empty)
            {
                return false;
            }

            return true;
        }
    }
}