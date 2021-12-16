using Quiz.App.Models;

namespace Quiz.App.Infrastructure.Repositories
{
    public interface IRepository<T> where T : BaseModel
    {
    }
}