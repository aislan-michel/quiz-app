using System;

namespace Quiz.App.Models.ViewModels
{
    public class CategoryViewModel
    {
        public CategoryViewModel(string name, int totalQuestions)
        {
            Name = name;
            TotalQuestions = totalQuestions;
        }
        
        public CategoryViewModel(Guid id, string name, bool haveQuestions)
        {
            Id = id;
            Name = name;
            HaveQuestions = haveQuestions;
        }
        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int TotalQuestions { get; set; }
        public bool HaveQuestions { get; set; }
    }
}