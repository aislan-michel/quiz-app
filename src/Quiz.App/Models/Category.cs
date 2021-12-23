using System.Collections.Generic;

namespace Quiz.App.Models
{
    public class Category : BaseModel
    {
        protected Category() { }
        
        public Category(string name)
        {
            Name = name;
            Questions = new List<Question>();
        }
        
        public string Name { get; private set; }
        public IReadOnlyCollection<Question> Questions { get; private set; }
    }
}