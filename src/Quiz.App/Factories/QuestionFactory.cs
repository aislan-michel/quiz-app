using System.Collections.Generic;
using Quiz.App.Models;

namespace Quiz.App.Factories
{
    public static class QuestionFactory
    {
        public static IEnumerable<Question> GenerateList()
        {
            return new List<Question>(3)
            {
                new("Quanto é 1+1?", new List<PossibleAnswer>(4)
                {
                    new("2", true),
                    new("11", false),
                    new("0", false),
                    new("1", false)
                }, 0),
                new("Quanto é 1+2?", new List<PossibleAnswer>(4)
                {
                    new("3", true),
                    new("55", false),
                    new("0", false),
                    new("2", false)
                }, 1),
                new("Quanto é 2+2?", new List<PossibleAnswer>(4)
                {
                    new("4", true),
                    new("36", false),
                    new("10", false),
                    new("1", false)
                }, 2),
            };
        }
    }
}