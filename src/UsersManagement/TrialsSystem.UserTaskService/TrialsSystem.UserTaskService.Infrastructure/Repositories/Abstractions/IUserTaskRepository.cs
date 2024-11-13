using TrialsSystem.UserTaskService.Domain.AggregatesModel.UserTaskAggregate;
using TrialsSystem.UserTaskService.Infrastructure.Repositories.QueryParameters;

namespace TrialsSystem.UserTaskService.Infrastructure.Repositories.Abstractions
{
    public interface IUserTaskRepository: IReadWriteRepository<UserTask>
    {
        Task<IEnumerable<UserTask>?> GetByUserId(string userId, CancellationToken ct = default, Pagination? pg = null);

        Task<UserTask?> GetByName( string name, string userId, CancellationToken ct = default);

        Task<UserTask?> DeleteByName(string name, string userId, CancellationToken ct = default);
    }
}
