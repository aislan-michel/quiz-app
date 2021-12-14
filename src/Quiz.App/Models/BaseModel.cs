using System;

namespace Quiz.App.Models
{
    public abstract class BaseModel
    {
        protected BaseModel()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
        }
        
        public Guid Id { get; }
        public DateTime CreatedAt { get; }
    }
}