namespace Quiz.App.ViewModels.Quiz
{
    public class ScoreViewModel
    {
        public int QuestionsCount { get; set; }
        public int CorrectQuestionsCount { get; set; }
        public int IncorrectQuestionsCount { get; set; }
        public int TimeToFinish { get; set; }
        public bool Approved { get; set; }
    }
}