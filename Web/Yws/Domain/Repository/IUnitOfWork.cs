namespace Domain.Repository
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
