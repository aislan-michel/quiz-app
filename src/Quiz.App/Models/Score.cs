namespace Quiz.App.Models
{
    public class Score
    {
        public Score(int value)
        {
            Value = value;
        }
        
        public int Value { get; private set; }
    }
}