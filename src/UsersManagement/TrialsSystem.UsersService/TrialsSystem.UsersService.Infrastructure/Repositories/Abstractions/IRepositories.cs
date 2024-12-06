using TrialsSystem.UsersService.Domain.AggregatesModel.UserAggregate;
using TrialsSystem.UsersService.Domain.AggregatesModel.DeviceAggregate;

namespace TrialsSystem.UsersService.Infrastructure.Repositories.Abstractions
{
    public interface IEntityRepository<T> : IReadWriteRepository<T>, IDeleteRepository<T> where T : class
    {
    }

    public interface IUserRepository : IEntityRepository<User>
    {
        public Task<IEnumerable<User>?> GetByEmail(string email, CancellationToken ct = default);
    }

    public interface IDeviceRepository : IEntityRepository<Device>
    {

    }

    public interface ICityRepository : IEntityRepository<City>
    {
    }
}
