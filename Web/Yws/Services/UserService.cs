using Contracts.User;
using Domain.Repository;
using Services.Abstractions;

namespace Services
{
    internal sealed class UserService : IUserService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public UserService(IRepositoryWrapper repositoryWrapper) => _repositoryWrapper = repositoryWrapper;

        public async Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var users = _repositoryWrapper.User.GetAllUsersAsync(cancellationToken);
            return null;
        }

        public Task<UserDto> GetByIdAsync(Guid ownerId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> CreateAsync(UserForCreationDto ownerForCreationDto, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Guid ownerId, UserForUpdateDto ownerForUpdateDto, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid ownerId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
