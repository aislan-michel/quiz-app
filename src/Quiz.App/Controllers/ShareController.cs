using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiz.App.Infrastructure.Repositories;
using Quiz.App.Models.Entities;

namespace Quiz.App.Controllers;

public class ShareController : Controller
{
    private readonly IRepository<Score> _scoreRepository;

    public ShareController(IRepository<Score> scoreRepository)
    {
        _scoreRepository = scoreRepository;
    }

    public async Task<IActionResult> Score(Guid id)
    {
        var score = await _scoreRepository.FirstAsync(x => x.Id == id);

        return View(score);
    } 
}