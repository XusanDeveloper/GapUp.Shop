using GapUp.Data.Contracts;
using GapUp.Domain.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GapUp.Data.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly GapUpDbContext RepositoryContext;

        public RepositoryBase(GapUpDbContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }
        public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);
        public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);
        public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ? RepositoryContext.Set<T>().AsNoTracking() : RepositoryContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ? RepositoryContext.Set<T>().Where(expression).AsNoTracking()
            : RepositoryContext.Set<T>().Where(expression);
    }
}
