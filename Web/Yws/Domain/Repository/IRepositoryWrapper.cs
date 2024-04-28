using Domain.Repository;

namespace Domain.Repository
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
    }
}
