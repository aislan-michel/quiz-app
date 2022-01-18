namespace Quiz.App.Models.ViewModels
{
    public class ScoreViewModel
    {
        public ScoreViewModel(string category, int questionsCount, int correctQuestionsCount, int incorrectQuestionsCount, int timeToFinish, bool approved)
        {
            Category = category;
            QuestionsCount = questionsCount;
            CorrectQuestionsCount = correctQuestionsCount;
            IncorrectQuestionsCount = incorrectQuestionsCount;
            TimeToFinish = timeToFinish;
            Approved = approved;
        }

        public ScoreViewModel(int questionsCount, int correctQuestionsCount, int incorrectQuestionsCount, int timeToFinish, bool approved)
        {
            QuestionsCount = questionsCount;
            CorrectQuestionsCount = correctQuestionsCount;
            IncorrectQuestionsCount = incorrectQuestionsCount;
            TimeToFinish = timeToFinish;
            Approved = approved;
        }
        
        public string Category { get; set; }
        public int QuestionsCount { get; set; }
        public int CorrectQuestionsCount { get; set; }
        public int IncorrectQuestionsCount { get; set; }
        public int TimeToFinish { get; set; }
        public bool Approved { get; set; }
    }
}