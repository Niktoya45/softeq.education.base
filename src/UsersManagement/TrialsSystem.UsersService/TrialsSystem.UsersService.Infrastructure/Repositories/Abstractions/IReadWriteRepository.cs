
using System.Linq.Expressions;
using TrialsSystem.UsersService.Infrastructure.Repositories.QueryParameters;

namespace TrialsSystem.UsersService.Infrastructure.Repositories.Abstractions
{
    public interface IReadWriteRepository<T>
    {
        Task<IEnumerable<T>?> GetAll(Expression<Func<T, bool>> query,
            CancellationToken ct = default,
            Pagination pg);

        Task<T?> GetById(string id, CancellationToken ct = default);

        T Add(T entity);

        Task<T?> Update(T entity, CancellationToken ct = default);
    } 
}
