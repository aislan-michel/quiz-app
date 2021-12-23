using System;

namespace Quiz.App.Models
{
    public class Score : BaseModel
    {
        protected Score() { }
        
        public Score(int value, TimeSpan timeDiff, Guid userId)
        {
            Value = value;
            TimeToFinish = timeDiff.Seconds;
            Passed = Value > 2; //TODO: pass the test if passed in 70% of questions
            UserId = userId;
        }
        
        public int Value { get; }
        public int TimeToFinish { get; }
        public bool Passed { get; }
        public Guid UserId { get; }
        public User User { get; private set; }
    }
}