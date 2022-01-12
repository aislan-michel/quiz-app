using System;

namespace Quiz.App.Models.ViewModels.Quiz
{
    public class CategoryViewModel
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool CategoryHaveQuestions { get; set; }
    }
}