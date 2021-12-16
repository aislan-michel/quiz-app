using System;

namespace Quiz.App.Models
{
    public class Score : BaseModel
    {
        public Score(int value, TimeSpan timeDiff)
        {
            Value = value;
            TimeToFinish = timeDiff.Seconds;
            Passed = Value > 2;
        }
        
        public int Value { get; }
        public int TimeToFinish { get; }
        public bool Passed { get; }
    }
}