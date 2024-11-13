

namespace TrialsSystem.UsersService.Infrastructure.Repositories.Abstractions
{
    public interface IDeleteRepository<T>
    {
        Task<T?> Delete(string id, CancellationToken ct = default);
    }
}
