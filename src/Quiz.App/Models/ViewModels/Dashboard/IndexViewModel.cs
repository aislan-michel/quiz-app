using System.Collections.Generic;

namespace Quiz.App.ViewModels.Dashboard
{
    public class IndexViewModel
    {
        public IEnumerable<ScoreViewModel> Scores { get; set; }
    }
}