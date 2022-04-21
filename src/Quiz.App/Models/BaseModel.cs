using System;

namespace Quiz.App.Models
{
    public abstract class BaseModel
    {
        protected BaseModel()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            Active = true;
        }
        
        public Guid Id { get; }
        public bool Active { get; private set; }
        public DateTime CreatedAt { get; }
    }
}