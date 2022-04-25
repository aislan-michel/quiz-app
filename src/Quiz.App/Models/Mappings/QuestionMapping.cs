using System.Collections.Generic;
using System.Linq;
using Quiz.App.InputModels;
using Quiz.App.Models.Entities;
using Quiz.App.Models.ViewModels.Question;

namespace Quiz.App.Models.Mappings
{
    public static class QuestionMapping
    {
        public static Question ToModel(this CreateQuestionInputModel inputModel)
        {
            return new Question(
                inputModel.Text, inputModel.Index, inputModel.CategoryId);
        }

        public static IEnumerable<QuestionViewModel> ToViewModel(this IEnumerable<Question> questions)
        {
            return questions.Select(x => new QuestionViewModel()
            {
                Id = x.Id,
                CategoryName = x.Category.Name,
                Index = x.Index,
                Text = x.Text
            });
        }

        public static QuestionViewModel ToDetailsViewModel(this Question question)
        {
            return new QuestionViewModel()
            {
                Id = question.Id,
                Text = question.Text,
                Index = question.Index,
                CategoryName = question.Category.Name,
                PossibleAnswers = question.PossibleAnswers.Select(x => new PossibleAnswersViewModel()
                {
                                IsAnswer = x.IsAnswer,
                                Text = x.Answer
                }),
                CountAnswers = question.CountAnswers(),
                HaveAnswers = question.HaveAnswers()
            };
        }
        
        public static QuestionViewModel ToUpdateViewModel(this Question question)
        {
            return new QuestionViewModel()
            {
                Id = question.Id,
                Text = question.Text,
                Index = question.Index,
                CategoryId = question.Category.Id
            };
        }
        
        public static QuestionViewModel ToSimulateViewModel(this Question question)
        {
            return new QuestionViewModel()
            {
                Text = question.Text,   
                PossibleAnswers = question.PossibleAnswers.Select(x => new PossibleAnswersViewModel()
                {
                    Id = x.Id,
                    IsAnswer = x.IsAnswer,
                    Text = x.Answer
                }),
                Id = question.Id,
                CategoryId = question.Category.Id
            };
        }

        public static QuestionViewModel ToQuizViewModel(this Question question)
        {
            return new QuestionViewModel()
            {
                            Text = question.Text,   
                            PossibleAnswers = question.PossibleAnswers.Select(x => new PossibleAnswersViewModel()
                            {
                                            Id = x.Id,
                                            IsAnswer = x.IsAnswer,
                                            Text = x.Answer
                            }),
                            Id = question.Id,
                            CategoryId = question.Category.Id
            };
        }
    }
}