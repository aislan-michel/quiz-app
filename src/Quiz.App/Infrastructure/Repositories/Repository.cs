using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Quiz.App.Models.Entities;

namespace Quiz.App.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly QuizDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(QuizDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Inactivate(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.CountAsync(expression);
        }

        public async Task<T> FirstAsync(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            var query = _dbSet.AsQueryable();

            if(expression != null)
            {
                query = query.Where(expression);
            }

            if(include != null)
            {
                query = include(query);
            }
            
            return await query.FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<T>> GetDataAsync(
            Expression<Func<T, bool>> expression = null, 
            Func<IQueryable<T>, 
            IIncludableQueryable<T, object>> include = null, 
            int? skip = null, int? take = null)
        {
            var query = _dbSet.AsQueryable();

            if(expression != null)
            {
                query = query.Where(expression);
            }

            if(include != null)
            {
                query = include(query);
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return await query.ToListAsync();
        }

        public async Task<T> FirstAsync(int skip, Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, 
                        IIncludableQueryable<T, object>> include = null)
        {
            var query = _dbSet.AsQueryable();

            if(expression != null)
            {
                query = query.Where(expression);
            }

            if(include != null)
            {
                query = include(query);
            }
            
            query = query.Skip(skip);

            return await query.FirstOrDefaultAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}