using System;

namespace Quiz.App.Models
{
    public class Score : BaseModel
    {
        protected Score() { }
        
        public Score(int value, int secondsDiff, string userId)
        {
            Value = value;
            TimeToFinish = secondsDiff;
            Passed = Value > 2; //TODO: pass the test if passed in 70% of questions
            UserId = userId;
        }
        
        public int Value { get; }
        public int TimeToFinish { get; }
        public bool Passed { get; }
        public string UserId { get; }
        public User User { get; private set; }
        
        //de qual categoria é esse score?
        
        //de qual quiz?
    }
}