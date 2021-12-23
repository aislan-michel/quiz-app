using Quiz.App.Models;

namespace Quiz.App.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}