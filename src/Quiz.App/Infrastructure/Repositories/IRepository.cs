using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using Quiz.App.Models.Entities;

namespace Quiz.App.Infrastructure.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T entity);

        void AddRange(IEnumerable<T> entities);
        
        void Remove(T entity);
        
        void Inactivate(T entity);
        
        void Update(T entity);
        
        Task SaveAsync();
        
        Task<T> GetByIdAsync(Guid id);
        
        Task<T> FirstAsync(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        
        Task<int> CountAsync(Expression<Func<T, bool>> expression);
        
        Task<List<T>> GetDataAsync(
            Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            int? skip = null,
            int? take = null);
        
        Task<T> FirstAsync(
                        Expression<Func<T, bool>> expression = null,
                        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                        int? skip = null);
    }
}