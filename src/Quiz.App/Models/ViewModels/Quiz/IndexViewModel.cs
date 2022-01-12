using System.Collections.Generic;

namespace Quiz.App.Models.ViewModels.Quiz
{
    public class IndexViewModel
    {
        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}