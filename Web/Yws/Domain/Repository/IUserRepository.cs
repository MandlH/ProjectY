using Domain.Entities;

namespace Domain.Repository
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<IEnumerable<User>> GetAllUsersAsync(CancellationToken cancellationToken);
        Task<User> GetUserByIdAsync(Guid ownerId);
    }
}
