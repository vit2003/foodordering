using Domain.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Repository;
using System.Linq.Expressions;

namespace Domain.Repositories.Implement
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly FoodOrderingDBDbContext _context;

        public RepositoryBase(FoodOrderingDBDbContext context)
        {
            _context = context;
        }
        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            if (!trackChanges) return _context.Set<T>().AsNoTracking();
            return _context.Set<T>();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            if (!trackChanges) return _context.Set<T>().Where(expression).AsNoTracking();
            return _context.Set<T>().Where(expression);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
