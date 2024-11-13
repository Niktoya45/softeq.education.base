

using System.Linq.Expressions;
using TrialsSystem.UserTaskService.Domain.AggregatesModel.UserTaskAggregate;
using TrialsSystem.UserTaskService.Infrastructure.Repositories.QueryParameters;

namespace TrialsSystem.UserTaskService.Infrastructure.Repositories.Abstractions
{
    public interface IReadWriteRepository<T>
    {
        Task<IEnumerable<T>?> GetAll(Expression<Func<UserTask, bool>>? query,
            CancellationToken ct = default,
            Pagination? pg = null);

        Task<T?> GetFirst(Expression<Func<UserTask, bool>>? query,
            CancellationToken ct = default);

        Task<T?> GetById(string id, CancellationToken ct = default);

        T Add(T entity);

        Task<T?> Update(T entity, CancellationToken ct = default);
    }
}
