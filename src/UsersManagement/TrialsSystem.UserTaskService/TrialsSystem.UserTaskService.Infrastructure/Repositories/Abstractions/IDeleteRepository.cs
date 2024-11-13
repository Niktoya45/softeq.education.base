
using System.Linq.Expressions;
using TrialsSystem.UserTaskService.Domain.AggregatesModel.UserTaskAggregate;

namespace TrialsSystem.UserTaskService.Infrastructure.Repositories.Abstractions
{
    public interface IDeleteRepository<T>
    {
        Task<T?> Delete(Expression<Func<UserTask, bool>>? query,
            CancellationToken ct = default);
    }
}
