

namespace TrialsSystem.UserTaskService.Infrastructure.Repositories.Abstractions
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAll(CancellationToken ct = default);

        Task<T> GetById(string id, CancellationToken ct = default);

        Task<T> Add(T entity, CancellationToken ct = default);

        Task<T> Update(T entity, CancellationToken ct = default);

        Task<T> Delete(string id, CancellationToken ct = default);
    }
}
