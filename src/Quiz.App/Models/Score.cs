using System;

namespace Quiz.App.Models
{
    public class Score : BaseModel
    {
        public Score(int value, TimeSpan timeDiff)
        {
            Value = value;
            TimeToFinish = Convert.ToInt32(timeDiff.Milliseconds);
        }
        
        public int Value { get; private set; }
        public int TimeToFinish { get; private set; }
        
    }
}