using System.Collections.Generic;
using System.Threading.Tasks;
using Quiz.App.Models.Entities;

namespace Quiz.App.Infrastructure.Repositories;

public interface IIdentityRepository
{
    Task<IEnumerable<User>> GetUsersInRoleCommon();
    Task<User> GetById(string id);
    Task Register(User user, string password);
    Task SignIn(string userName, string password);
    Task SignOut();
}