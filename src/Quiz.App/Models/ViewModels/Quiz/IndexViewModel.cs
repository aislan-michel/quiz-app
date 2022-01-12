using System.Collections.Generic;

namespace Quiz.App.ViewModels.Quiz
{
    public class IndexViewModel
    {
        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}