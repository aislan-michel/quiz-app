using System.Collections.Generic;
using Quiz.App.Models;

namespace Quiz.App.Factories
{
    public static class QuestionFactory
    {
        public static Question Generate()
        {
            return new("Quanto é 1+1 ?", new List<PossibleAnswer>(4)
            {
                new("2", true),
                new("11", false),
                new("0", false),
                new("1", false)
            });
        }
    }
}