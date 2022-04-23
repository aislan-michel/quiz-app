using System;

namespace Quiz.App.ViewModels.Quiz
{
    public class IndexViewModel
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool CategoryHaveQuestions { get; set; }
    }
}