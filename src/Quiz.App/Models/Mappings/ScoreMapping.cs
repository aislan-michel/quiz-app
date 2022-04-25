using System.Collections.Generic;
using System.Linq;
using Quiz.App.Models.Entities;
using Quiz.App.Models.ViewModels;

namespace Quiz.App.Models.Mappings;

public static class ScoreMapping
{
    public static IEnumerable<ScoreViewModel> ToDashboardViewModel(this IEnumerable<Score> scores)
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

    public static ScoreViewModel ToQuizViewModel(this Score score)
    {
        return new ScoreViewModel()
        {
                        QuestionsCount = score.QuestionsCount,
                        CorrectQuestionsCount = score.CorrectQuestionsCount,
                        IncorrectQuestionsCount = score.IncorrectQuestionsCount,
                        SecondsToFinish = score.TimeToFinish,
                        Approved = score.Approved

        };
    }
}