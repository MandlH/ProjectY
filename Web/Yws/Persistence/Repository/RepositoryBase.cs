using System.Linq.Expressions;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;

namespace Persistence.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationDbContext ApplicationContext { get; set; }
        protected IUnitOfWork UnitOfWork { get; set; }

        public RepositoryBase(ApplicationDbContext applicationContext, IUnitOfWork unitOfWork)
        {
            ApplicationContext = applicationContext;
            UnitOfWork = unitOfWork;
        }

        public IQueryable<T> FindAll()
        {
            return ApplicationContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return ApplicationContext.Set<T>()
                .Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            ApplicationContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            ApplicationContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            ApplicationContext.Set<T>().Remove(entity);
        }
    }
}
