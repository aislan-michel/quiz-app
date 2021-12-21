using System;
using System.Collections.Generic;
using Quiz.App.InputModels;
using Quiz.App.Models;

namespace Quiz.App.Mappings
{
    public static class AnswerMapping
    {
        public static IEnumerable<PossibleAnswer> ToModel(this CreateAnswerInputModel inputModel)
        {
            var model = new List<PossibleAnswer>(4);

            foreach (var answer in inputModel.Answers)
            {
                var isCorrect = answer.IndexOf(answer, StringComparison.Ordinal) == inputModel.Correct;
                
                model.Add(new PossibleAnswer(answer, isCorrect, inputModel.QuestionId));
            }

            return model;
        }
    }
}