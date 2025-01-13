using TrialsSystem.UserTaskService.Infrastructure.Repositories.QueryParameters;
using TrialsSystem.UserTaskService.Infrastructure.Repositories.Abstractions;
using TrialsSystem.UserTaskService.Domain.AggregatesModel.UserTaskAggregate;
using TrialsSystem.UserTaskService.Infrastructure.Context;
using TrialsSystem.UserTaskService.Infrastructure.Exceptions;
using MongoDB.Driver.Linq;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace TrialsSystem.UserTaskService.Infrastructure.Repositories.Implementations
{
    public class UserTaskRepository:IUserTaskRepository
    {
        private UserTaskDbContext _dbcontext;

        FilterDefinition<UserTask> filterDeleted = Builders<UserTask>.Filter.Where(ut => !ut.IsDeleted);

        public UserTaskRepository(UserTaskDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<UserTask>?> GetAll(
            Expression<Func<UserTask, bool>>? query = null, 
            CancellationToken ct = default,
            Pagination? pg = null)
        {

            var addfilter = query == null ? Builders<UserTask>.Filter.Empty : Builders<UserTask>.Filter.Where(query);

            pg ??= new Pagination();
            return await _dbcontext.UserTasks.Find(filterDeleted & addfilter).Skip(pg.Skip).Limit(pg.Take).ToListAsync(ct);
        }

        public async Task<UserTask?> GetFirst(
            Expression<Func<UserTask, bool>>? query = null,
            CancellationToken ct = default)
        {
            var addfilter = query == null ? Builders<UserTask>.Filter.Empty : Builders<UserTask>.Filter.Where(query);
            
            return await _dbcontext.UserTasks.Find(filterDeleted & addfilter).FirstAsync();
        }

        public async Task<UserTask?> GetById(string id, CancellationToken ct = default)
        {
            return await GetFirst(ut => ut.Id == id, ct);
        }

        public async Task<IEnumerable<UserTask>?> GetByUserId(string userId, CancellationToken ct = default, Pagination? pg = null)
        {
            return await GetAll(ut => ut.UserId == userId, ct, pg);
        }

        public async Task<IEnumerable<UserTask>?> GetByName(string name, string userId, CancellationToken ct = default)
        {
            return await GetAll(ut => ut.Name == name && ut.UserId == userId, ct, null);
        }
        public UserTask Add(UserTask utask)
        {
            try
            {

                _dbcontext.UserTasks.InsertOne(utask);

            }
            catch (MongoWriteException)
            {
                throw new UserTaskExistsException("UserTask already exists");
            }
            catch (MongoException me)
            {
                throw new InnerDbException($"Inner exception has occurred: {me.Message}");
            }

            return utask;

        }

        public async Task<UserTask?> Update(UserTask utask, CancellationToken ct = default)
        {
            var filter = Builders<UserTask>.Filter.Eq(ut => ut.UserId, utask.UserId)
                                            & Builders<UserTask>.Filter.Eq(ut => ut.Name, utask.Name);

            utask.SetUpdatedTime();

            var res = await _dbcontext.UserTasks.ReplaceOneAsync(
                filterDeleted & filter,
                utask,
                new ReplaceOptions { IsUpsert = false },
                ct);

            if (!res.IsAcknowledged)
                return null;

            return utask;

        }

        public async Task<UserTask?> DeleteByName(string name, string userId, CancellationToken ct = default)
        {
            var utask = await GetFirst(ut => ut.Name == name && ut.UserId == userId, ct);

            if (utask == null)
            {
                return utask;
            }

            utask.SetDeleted();

            var filterId = Builders<UserTask>.Filter.Eq(ut => ut.Id, utask.Id);
            var update = Builders<UserTask>.Update.Set(ut => ut.IsDeleted, true);

            _dbcontext.UserTasks.UpdateOne(filterDeleted & filterId, update);

            return utask;
        }
    }
}
