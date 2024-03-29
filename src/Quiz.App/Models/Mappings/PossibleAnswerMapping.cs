﻿using System.Collections.Generic;
using System.Linq;
using Quiz.App.Models.InputModels;
using Quiz.App.Models.Entities;

namespace Quiz.App.Models.Mappings
{
    public static class PossibleAnswerMapping
    {
        public static IEnumerable<PossibleAnswer> ToEntity(this CreateAnswerInputModel inputModel)
        {
            var model = new List<PossibleAnswer>(4);

            foreach (var answer in inputModel.Answers.Select((value, i) => new { i, value }))
            {
                var isCorrect = (answer.i + 1) == inputModel.Correct;
                
                model.Add(new PossibleAnswer(answer.value, isCorrect, inputModel.QuestionId));
            }

            return model;
        }
    }
}