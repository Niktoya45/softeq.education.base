using TrialsSystem.UsersService.Infrastructure.Repositories.Abstractions;
using TrialsSystem.UsersService.Domain.AggregatesModel.UserAggregate;

namespace TrialsSystem.UsersService.Infrastructure.Repositories.Implementations
{
    public class CityRepository : EntityRepository<City>, ICityRepository
    {
        public CityRepository(ServiceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
