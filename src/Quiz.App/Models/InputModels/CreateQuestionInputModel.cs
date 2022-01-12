using System;
using System.ComponentModel.DataAnnotations;

namespace Quiz.App.Models.InputModels
{
    public class CreateQuestionInputModel
    {
        [Required]
        public string Text { get; set; }
        
        [Required]
        [Range(1, 15)]
        public int Index { get; set; }
        
        [Required]
        public Guid CategoryId { get; set; }
    }
}