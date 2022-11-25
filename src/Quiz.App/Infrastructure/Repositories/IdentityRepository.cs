using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Quiz.App.Infrastructure.Notification;
using Quiz.App.Models;
using Quiz.App.Models.Entities;

namespace Quiz.App.Infrastructure.Repositories;

public class IdentityRepository : IIdentityRepository
{
    private readonly QuizDbContext _dbContext;
    private readonly UserManager<User> _userManager;
    private readonly INotificator _notificator;
    private readonly SignInManager<User> _signInManager;
    
    public IdentityRepository(QuizDbContext dbContext, UserManager<User> userManager, INotificator notificator, SignInManager<User> signInManager)
    {
        _dbContext = dbContext;
        _userManager = userManager;
        _notificator = notificator;
        _signInManager = signInManager;
    }

    public async Task<IEnumerable<User>> GetUsersInRoleCommon()
    {
        var users = await _userManager.GetUsersInRoleAsync(Roles.Common);

        return users ?? new List<User>();
    }

    public async Task<User> GetById(string id)
    {
        return await _dbContext.Users
            .Include(x => x.Scores)
            .ThenInclude(x => x.Category)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task Register(User user, string password)
    {
        var created = await _userManager.CreateAsync(user, password);

        if (!created.Succeeded)
        {
            _notificator.Add("Password", string.Join("\n", created.Errors.Select(x => x.Description)));
            return;
        }

        await _userManager.AddToRoleAsync(user, Roles.Common);
    }
    
    public async Task SignIn(string userName, string password)
    {
        var user = await _userManager.FindByNameAsync(userName);

        await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Sid, user.Id));

        var signInResult = await _signInManager.PasswordSignInAsync(userName, password, false, false);

        if (!signInResult.Succeeded)
        {
            _notificator.Add("Password", "login or password is invalid");
        }
    }

    public async Task SignOut()
    {
        await _signInManager.SignOutAsync();
    }
}