using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;

namespace Persistence.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext applicationContext, IUnitOfWork unitOfWork)
            : base(applicationContext, unitOfWork)
        {
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync(CancellationToken cancellationToken)
        {
            var t = FindAll();
            return t.ToList();
        }

        public async Task<User> GetUserByIdAsync(Guid ownerId)
        {
            return await FindByCondition(user => user.Id.Equals(ownerId))
                .FirstOrDefaultAsync();
        }
    }
}
