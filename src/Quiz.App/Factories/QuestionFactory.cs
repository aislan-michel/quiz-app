using System;
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
                    new("2", true,Guid.NewGuid()),
                    new("11", false,Guid.NewGuid()),
                    new("0", false,Guid.NewGuid()),
                    new("1", false,Guid.NewGuid())
                }, 0),
                new("Quanto é 1+2?", new List<PossibleAnswer>(4)
                {
                    new("3", true,Guid.NewGuid()),
                    new("55", false,Guid.NewGuid()),
                    new("0", false,Guid.NewGuid()),
                    new("2", false,Guid.NewGuid())
                }, 1),
                new("Quanto é 2+2?", new List<PossibleAnswer>(4)
                {
                    new("4", true,Guid.NewGuid()),
                    new("36", false,Guid.NewGuid()),
                    new("10", false,Guid.NewGuid()),
                    new("1", false,Guid.NewGuid())
                }, 2),
            };
        }
    }
}