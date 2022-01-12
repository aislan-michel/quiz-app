namespace Quiz.App.ViewModels.Dashboard
{
    public class ScoreViewModel
    {
        public string Category { get; set; }
        public int QuestionsCount { get; set; }
        public int CorrectQuestions { get; set; }
        public int IncorrectQuestions { get; set; }
        public int TimeToFinish { get; set; }
        public bool Approved { get; set; }
    }
}