using Domain.Repository;

namespace Persistence.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly IUnitOfWork _unitOfWork;

        public RepositoryWrapper(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            User = userRepository;
        }

        public IUserRepository User { get; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
