using System.Collections.Generic;

namespace Quiz.App.Models.ViewModels
{
    public class CategoryIndexViewModel
    {
        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}