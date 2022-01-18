using System;

namespace Quiz.App.Models.Entities
{
    public class Score : BaseEntity
    {
        protected Score() { }
        
        public Score(
            string userId, Guid categoryId, int questionsCount, int correctAnswers, int timeToFinish)
        {
            UserId = userId;
            CategoryId = categoryId;
            QuestionsCount = questionsCount;
            CorrectQuestionsCount = correctAnswers;
            SetIncorrectQuestionsCount();
            TimeToFinish = timeToFinish;
            Approved = VerifyIfApproved();
        }
        
        public string UserId { get; }
        public User User { get; private set; }
        public Guid CategoryId { get; private set; }
        public Category Category { get; private set; }
        public int QuestionsCount { get; private set; }
        public int CorrectQuestionsCount { get; private set; }
        public int IncorrectQuestionsCount { get; private set; }
        public int TimeToFinish { get; }
        public bool Approved { get; }

        private bool VerifyIfApproved()
        {
            const int two = 2;
            
            var x = QuestionsCount / two;

            return CorrectQuestionsCount >= x;
        }

        private void SetIncorrectQuestionsCount()
        {
            IncorrectQuestionsCount = QuestionsCount - CorrectQuestionsCount;
        }
    }
}