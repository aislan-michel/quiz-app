using System;
using System.ComponentModel.DataAnnotations;

namespace Quiz.App.InputModels
{
    public class CreateAnswerInputModel
    {
        [Required]
        public Guid QuestionId { get; set; }
        
        [Required]
        [MaxLength(4)]
        public string[] Answers { get; set; }
        
        [Required]
        [Range(1, 4)]
        public int Correct { get; set; }
    }
}