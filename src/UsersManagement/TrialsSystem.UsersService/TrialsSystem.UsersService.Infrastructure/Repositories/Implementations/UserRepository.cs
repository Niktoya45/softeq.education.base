using TrialsSystem.UsersService.Infrastructure.Repositories.Abstractions;
using TrialsSystem.UsersService.Domain.AggregatesModel.UserAggregate;
using Microsoft.EntityFrameworkCore;

namespace TrialsSystem.UsersService.Infrastructure.Repositories.Implementations
{
    public class UserRepository: IRepository<User>
    {
        private ServiceDbContext _dbContext;

        public UserRepository(ServiceDbContext dbContext) {
            _dbContext = dbContext;
        }
        public async Task<List<User>> GetAll(CancellationToken ct = default) {
            return await _dbContext.Set<User>().ToListAsync(ct);  
        }

        public async Task<User> GetById(string id, CancellationToken ct = default) {
            return await _dbContext.Set<User>().FirstOrDefaultAsync(u => u.Id == id, ct);
        }

        public async Task Add(User user, CancellationToken ct = default) {
            await _dbContext.Set<User>().AddAsync(user, ct);
        }

        public async Task Update(User user, CancellationToken ct = default) { 
            _dbContext.Set<User>().Update(user);
        }

        public async Task Delete(User user, CancellationToken ct = default) {
            _dbContext.Set<User>().Remove(user);
        }

    }
}
