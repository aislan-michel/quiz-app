using System;
using System.Collections.Generic;

namespace Quiz.App.Models.ViewModels
{
    public class QuestionViewModel
    {
        public QuestionViewModel(Guid id, string text, int index, string categoryName)
        {
            Id = id;
            Text = text;
            Index = index;
            CategoryName = categoryName;
        }

        public QuestionViewModel(
            Guid id, string text, int index, 
            Guid categoryId, string categoryName, 
            IEnumerable<PossibleAnswerViewModel> possibleAnswers)
        {
            Id = id;
            Text = text;
            Index = index;
            CategoryId = categoryId;
            CategoryName = categoryName;
            PossibleAnswers = possibleAnswers;
        }
        
        public Guid Id { get; set; }
        public string Text { get; set; }
        public int Index { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public IEnumerable<PossibleAnswerViewModel> PossibleAnswers { get; set; }
    }
}