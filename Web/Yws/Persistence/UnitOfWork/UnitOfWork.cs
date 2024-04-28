using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Persistence.Database;

namespace Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RepositoryDbContext _repositoryDbContext;

        private IDbContextTransaction? _transaction;

        public UnitOfWork(RepositoryDbContext repositoryDbContext) => _repositoryDbContext = repositoryDbContext;

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return _repositoryDbContext.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateException ex)
            {
                throw new InvalidOperationException("Error updating entities.", ex);
            }
        }

        public void Commit()
        {
            try
            {
                _transaction?.Commit();
            }
            catch (InvalidOperationException ex)
            {
                Rollback();
                throw new InvalidOperationException("Error committing transaction.", ex);
            }
        }

        public void Rollback()
        {
            try
            {
                _transaction?.Rollback();
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("Error rolling back transaction.", ex);
            }
        }

        public void BeginTransaction()
        {
            _transaction = _repositoryDbContext.Database.BeginTransaction();
        }
    }
}
