using System;

namespace Quiz.App.Models.ViewModels;

public class CategoryViewModel
{
    public string Name { get; set; }
    public int TotalQuestions { get; set; }

    public Guid Id { get; set; }
    public bool HaveQuestions { get; set; }
}