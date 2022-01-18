using System.Collections.Generic;

namespace Quiz.App.Models.ViewModels
{
    public class QuestionIndexViewModel
    {
        public QuestionIndexViewModel(IEnumerable<QuestionViewModel> questions)
        {
            Questions = questions;
        }
        
        public IEnumerable<QuestionViewModel> Questions { get; set; }
    }
}