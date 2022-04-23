using System.Collections.Generic;
using System.Linq;
using Quiz.App.Models.Entities;
using Quiz.App.Models.ViewModels.Dashboard;

namespace Quiz.App.Models.Mappings;

public static class DashboardMapping
{
    public static IEnumerable<ScoreViewModel> ToViewModel(this IEnumerable<Score> scores)
    {
        return scores.Select(x => new ScoreViewModel()
        {
            CategoryName = x.Category.Name,
            QuestionsCount = x.QuestionsCount,
            CorrectQuestionsCount = x.CorrectQuestionsCount,
            IncorrectQuestionsCount = x.IncorrectQuestionsCount,
            SecondsToFinish = x.TimeToFinish,
            Approved = x.Approved
        });
    }
}