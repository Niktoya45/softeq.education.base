using TrialsSystem.UserTaskService.Infrastructure.Repositories.Abstractions;
using TrialsSystem.UserTaskService.Domain.AggregatesModel.UserTaskAggregate;
using TrialsSystem.UserTaskService.Infrastructure.Context;
using MongoDB.Driver.Linq;
using MongoDB.Driver;

namespace TrialsSystem.UserTaskService.Infrastructure.Repositories.Implementations
{
    public class UserTaskRepository:IRepository<UserTask>
    {
        private UserTaskDbContext _dbcontext;

        FilterDefinition<UserTask> filterDeleted = Builders<UserTask>.Filter.Where(ut => !ut.IsDeleted);

        public UserTaskRepository(UserTaskDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<UserTask>> GetAll(CancellationToken ct = default)
        {
            return await _dbcontext.UserTasks.ToListAsync(ct);
        }

        public async Task<UserTask> GetById(string id, CancellationToken ct = default)
        {
            return await _dbcontext.UserTasks.FindAsync(id, ct);
        }

        public async Task<UserTask> Add(UserTask task, CancellationToken ct = default)
        {
            await _dbcontext.UserTasks.AddAsync(task, ct);

            return task;

        }

        public async Task<UserTask> Update(UserTask task, CancellationToken ct = default)
        {

            _dbcontext.UserTasks.Update(task);

            return task;

        }

        public async Task<UserTask> Delete(string id, CancellationToken ct = default) {

            var task = await _dbcontext.UserTasks.FindAsync(id, ct);

            if (task == null)
            {
                return task;
            }

            task.SetDeleted();

            _dbcontext.Update(task);

            return task;
        }
    }
}
