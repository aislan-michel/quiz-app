using System.Collections.Generic;

namespace Quiz.App.Models.ViewModels.Dashboard
{
    public class IndexViewModel
    {
        public IEnumerable<ScoreViewModel> Scores { get; set; }
    }
}