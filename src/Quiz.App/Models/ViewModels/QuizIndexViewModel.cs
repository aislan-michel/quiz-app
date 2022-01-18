using System.Collections.Generic;

namespace Quiz.App.Models.ViewModels
{
    public class QuizIndexViewModel
    {
        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}