using System.Collections.Generic;
using System.Linq;
using Quiz.App.Models.Entities;
using Quiz.App.Models.ViewModels;

namespace Quiz.App.Mappings
{
    public static class ScoreMapping
    {
        public static DashboardIndexViewModel ToDashboardIndexViewModel(this IEnumerable<Score> scores)
        {
            return new()
            {
                Scores = scores.Select(x => new ScoreViewModel
                (
                    x.Category.Name,
                    x.QuestionsCount,
                    x.CorrectQuestionsCount,
                    x.IncorrectQuestionsCount,
                    x.TimeToFinish,
                    x.Approved
                ))
            }; 
        }

        public static ScoreViewModel ToQuizScoreViewModel(this Score score)
        {
            return new
            (
                score.QuestionsCount,
                score.CorrectQuestionsCount,
                score.IncorrectQuestionsCount,
                score.TimeToFinish,
                score.Approved
            );
        }
    }
}