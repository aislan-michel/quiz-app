using System;

namespace Quiz.App.InputModels
{
    public class CreateQuestionInputModel
    {
        public string Text { get; set; }
        public int Index { get; set; }
        public Guid CategoryId { get; set; }
    }
}