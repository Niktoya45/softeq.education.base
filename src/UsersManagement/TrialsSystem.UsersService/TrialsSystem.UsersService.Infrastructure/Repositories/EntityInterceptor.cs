using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using TrialsSystem.UsersService.Domain.AggregatesModel.Base;

namespace TrialsSystem.UsersService.Infrastructure.Repositories
{
    public class EntityInterceptor : SaveChangesInterceptor
    {
        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = default)
        {
            SetEntityProperties(eventData.Context);

            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        public override InterceptionResult<int> SavingChanges(
            DbContextEventData eventData,
            InterceptionResult<int> result)
        {
            SetEntityProperties(eventData.Context);

            return base.SavingChanges(eventData, result);
        }

        private static void SetEntityProperties(DbContext? ctx)
        {
            if (ctx == null) return;

            DateTime utcn = DateTime.UtcNow;

            foreach (var entry in ctx.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added when entry.Entity is Entity entity:
                        entity.CreatedDate = utcn;
                        entity.IsDeleted = false;
                        break;

                    case EntityState.Modified when entry.Entity is Entity entity:
                        entity.LastModifiedDate = utcn;
                        break;

                    default: break;

                }
            }
        }

    }
}

