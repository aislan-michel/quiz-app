using System;

namespace Quiz.App.Models.ViewModels.Question
{
    public class QuestionViewModel
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public int Index { get; set; }
        public string CategoryName { get; set; }
    }
}