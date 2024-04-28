using System.Linq.Expressions;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;

namespace Persistence.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryDbContext RepositoryContext { get; set; }
        protected IUnitOfWork UnitOfWork { get; set; }

        public RepositoryBase(RepositoryDbContext repositoryContext, IUnitOfWork unitOfWork)
        {
            RepositoryContext = repositoryContext;
            UnitOfWork = unitOfWork;
        }

        public IQueryable<T> FindAll()
        {
            return RepositoryContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return RepositoryContext.Set<T>()
                .Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            RepositoryContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            RepositoryContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);
        }
    }
}
