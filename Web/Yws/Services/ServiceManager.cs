using Domain.Repository;
using Services.Abstractions;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IUserService> _lazyUserService;

        public ServiceManager(IRepositoryWrapper repositoryWrapper)
        {
            _lazyUserService = new Lazy<IUserService>(() => new UserService(repositoryWrapper));
        }

        public IUserService UserService => _lazyUserService.Value;
    }
}
