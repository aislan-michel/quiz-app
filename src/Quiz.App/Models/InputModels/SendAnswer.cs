using System;

namespace Quiz.App.Models.InputModels
{
    public class SendAnswer
    {
        public string Answer { get; set; }
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
    }
}