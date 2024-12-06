using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TrialsSystem.UsersService.Domain.AggregatesModel.Base;
using TrialsSystem.UsersService.Infrastructure.Repositories.Abstractions;
using TrialsSystem.UsersService.Infrastructure.Repositories.QueryParameters;

namespace TrialsSystem.UsersService.Infrastructure.Repositories.Implementations
{
    public abstract class EntityRepository<T> : IEntityRepository<T> where T : Entity
    {
        protected DbContext _dbContext;
        protected DbSet<T> _dbSet { get; init; }

        public EntityRepository(ServiceDbContext dbContext)
        {
            _dbSet = dbContext.Set<T>();
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<T>?> GetAll(Expression<Func<T, bool>>? query = null,
            CancellationToken ct = default,
            Pagination? pg = null)
        {
            pg ??= new Pagination();

            return await _dbSet.AsQueryable().Where(query??(_=>true))
                .AsQueryable().Where(e => !e.IsDeleted)
                .AsQueryable().Skip(pg.Skip ?? 0).Take(pg.Take ?? 0)
                .ToListAsync(ct);
        }

        public async Task<T?> GetById(string id, CancellationToken ct = default)
        {
            return await _dbSet.AsQueryable().FirstOrDefaultAsync(e => !e.IsDeleted && e.Id == id, ct);
        }

        public T Add(T entity)
        {
            return _dbSet.Add(entity).Entity;
        }

        public async Task<T?> Update(T entity, CancellationToken ct = default)
        {
            T? instance = await _dbSet.AsQueryable().FirstOrDefaultAsync(e => !e.IsDeleted && e.Id == entity.Id, ct);
            if (instance == null)
                return instance;

            return _dbSet.Update(entity).Entity;
        }

        public async Task<T?> Delete(string id, CancellationToken ct = default)
        {
            T? instance = await _dbSet.AsQueryable().FirstOrDefaultAsync(e => !e.IsDeleted && e.Id == id, ct);
            if (instance == null)
                return instance;

            instance.IsDeleted = true;

            return _dbSet.Update(instance).Entity;
        }

    }
}
