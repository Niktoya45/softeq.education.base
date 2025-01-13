using TrialsSystem.UsersService.Infrastructure.Repositories.Abstractions;
using TrialsSystem.UsersService.Domain.AggregatesModel.DeviceAggregate;

namespace TrialsSystem.UsersService.Infrastructure.Repositories.Implementations
{
    public class DeviceRepository:EntityRepository<Device>, IDeviceRepository
    {
        public DeviceRepository(ServiceDbContext dbContext):base(dbContext) 
        { 
        }
    }
}
