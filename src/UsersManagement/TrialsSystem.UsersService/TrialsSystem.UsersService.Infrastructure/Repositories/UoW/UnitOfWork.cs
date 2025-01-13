using TrialsSystem.UsersService.Infrastructure.Repositories.Abstractions;
using TrialsSystem.UsersService.Infrastructure.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;

namespace TrialsSystem.UsersService.Infrastructure.Repositories.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        ServiceDbContext _dbContext;
        public IUserRepository Users { get; private set; }
        public IDeviceRepository Devices { get; private set; }
        public ICityRepository Cities { get; private set; }

        public UnitOfWork(ServiceDbContext dbContext)
        {
            _dbContext = dbContext;

            Users = new UserRepository(dbContext);

            Devices = new DeviceRepository(dbContext);

            Cities = new CityRepository(dbContext);
        }

        public async void Commit(CancellationToken ct)
        {
            try
            {
                await _dbContext.SaveChangesAsync(ct);
            }
            catch(Exception e)
            {
                switch (e)
                {
                    case DbUpdateConcurrencyException uce: break;

                    default: throw;
                }
            }
        }
    }
}
