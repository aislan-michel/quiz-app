using System;

namespace Quiz.App.Models
{
    public abstract class BaseModel
    {
        protected BaseModel()
        {
            Id = Guid.NewGuid();
        }
        
        public Guid Id { get; private set; }
    }
}