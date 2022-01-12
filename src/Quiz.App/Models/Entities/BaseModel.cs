using System;

namespace Quiz.App.Models.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
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