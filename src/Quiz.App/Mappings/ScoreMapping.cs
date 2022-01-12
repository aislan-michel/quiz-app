using System.Collections.Generic;
using System.Linq;
using Quiz.App.Models;
using Quiz.App.ViewModels.Dashboard;

namespace Quiz.App.Mappings
{
    public static class ScoreMapping
    {
        public static IEnumerable<IndexViewModel> ToIndexViewModel(this IEnumerable<Score> scores)
        {
            return scores.Select(x => new IndexViewModel()
            {
                Category = x.Category.Name,
                QuestionsCount = x.QuestionsCount,
                CorrectQuestions = x.CorrectQuestionsCount,
                IncorrectQuestions = x.IncorrectQuestionsCount,
                TimeToFinish = x.TimeToFinish,
                Approved = x.Approved
            });
        }
    }
}