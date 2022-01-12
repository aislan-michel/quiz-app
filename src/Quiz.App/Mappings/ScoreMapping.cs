using System.Collections.Generic;
using System.Linq;
using Quiz.App.Models.Entities;
using Quiz.App.Models.ViewModels.Dashboard;

namespace Quiz.App.Mappings
{
    public static class ScoreMapping
    {
        public static IndexViewModel ToIndexViewModel(this IEnumerable<Score> scores)
        {
            return new()
            {
                Scores = scores.Select(x => new ScoreViewModel
                {
                    Category = x.Category.Name,
                    QuestionsCount = x.QuestionsCount,
                    CorrectQuestions = x.CorrectQuestionsCount,
                    IncorrectQuestions = x.IncorrectQuestionsCount,
                    TimeToFinish = x.TimeToFinish,
                    Approved = x.Approved
                })
            }; 
        }

        public static Models.ViewModels.Quiz.ScoreViewModel ToQuizScoreViewModel(this Score score)
        {
            return new()
            {
                QuestionsCount = score.QuestionsCount,
                CorrectQuestionsCount = score.CorrectQuestionsCount,
                IncorrectQuestionsCount = score.IncorrectQuestionsCount,
                TimeToFinish = score.TimeToFinish,
                Approved = score.Approved
            };
        }
    }
}