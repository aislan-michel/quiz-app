using System.Collections.Generic;

namespace Quiz.App.Models.ViewModels
{
    public class DashboardIndexViewModel
    {
        public IEnumerable<ScoreViewModel> Scores { get; set; }
    }
}