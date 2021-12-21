using System;

namespace Quiz.App.InputModels
{
    public class CreateAnswerInputModel
    {
        public Guid QuestionId { get; set; }
        public string[] Answers { get; set; }
        public int Correct { get; set; }
    }
}