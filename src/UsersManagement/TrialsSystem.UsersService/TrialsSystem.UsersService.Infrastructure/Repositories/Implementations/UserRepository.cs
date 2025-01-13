using TrialsSystem.UsersService.Infrastructure.Repositories.Abstractions;
using TrialsSystem.UsersService.Domain.AggregatesModel.UserAggregate;
using System.Runtime.CompilerServices;

namespace TrialsSystem.UsersService.Infrastructure.Repositories.Implementations
{
    public class UserRepository: EntityRepository<User>, IUserRepository
    {
        public UserRepository(ServiceDbContext dbContext):base(dbContext) {

        }

        public async Task<IEnumerable<User>?> GetByEmail(string email, CancellationToken ct = default) 
        {
            return await base.GetAll(u => u.Email == email, ct);
        }
    }
}
