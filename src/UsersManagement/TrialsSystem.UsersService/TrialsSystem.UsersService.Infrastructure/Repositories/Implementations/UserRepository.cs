using TrialsSystem.UsersService.Infrastructure.Repositories.Abstractions;
using TrialsSystem.UsersService.Domain.AggregatesModel.UserAggregate;

namespace TrialsSystem.UsersService.Infrastructure.Repositories.Implementations
{
    public class UserRepository: EntityRepository<User>, IUserRepository
    {
        public UserRepository(ServiceDbContext dbContext):base(dbContext) {

        }

    }
}
