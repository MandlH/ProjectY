using Contracts.User;

namespace Services.Abstractions
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<UserDto> GetByIdAsync(Guid ownerId, CancellationToken cancellationToken = default);

        Task<UserDto> CreateAsync(UserForCreationDto ownerForCreationDto, CancellationToken cancellationToken = default);

        Task UpdateAsync(Guid ownerId, UserForUpdateDto ownerForUpdateDto, CancellationToken cancellationToken = default);

        Task DeleteAsync(Guid ownerId, CancellationToken cancellationToken = default);
    }
}
