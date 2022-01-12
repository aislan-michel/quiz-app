using System.Collections.Generic;

namespace Quiz.App.Models.ViewModels.Category
{
    public class IndexViewModel
    {
        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}