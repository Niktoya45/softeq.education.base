
namespace TrialsSystem.UsersService.Infrastructure.Repositories.Abstractions
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAll(CancellationToken ct = default);

        Task<T> GetById(string id, CancellationToken ct = default);

        Task Add(T entity, CancellationToken ct = default);

        Task Update(T entity, CancellationToken ct = default);

        Task Delete(T entity, CancellationToken ct = default);
    } 
}
