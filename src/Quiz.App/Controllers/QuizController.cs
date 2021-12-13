using Microsoft.AspNetCore.Mvc;
using Quiz.App.Factories;
using Quiz.App.InputModels;
using Quiz.App.Models;

namespace Quiz.App.Controllers
{
    public class QuizController : Controller
    {
        private static readonly Question Question = QuestionFactory.Generate();
        
        // GET
        public IActionResult Index()
        {
            return View(Question);
        }

        public IActionResult SendAnswer(SendAnswer inputModel)
        {
            var correctAnswer = Question.GetCorrectAnswer();

            return View(inputModel.Answer == correctAnswer ? "Correct" : "Incorrect");
        }
    }
}