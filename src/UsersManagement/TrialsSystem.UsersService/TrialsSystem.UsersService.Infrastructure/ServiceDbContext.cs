using Microsoft.EntityFrameworkCore;

namespace TrialsSystem.UsersService.Infrastructure
{
    public sealed class ServiceDbContext : DbContext
    {
        private readonly string _connectionStr = @"Server=(localdb)\mssqllocaldb;Database=user_info_db;";

        protected override void OnConfiguring(DbContextOptionsBuilder dbctxob)
        {
            dbctxob.UseSqlServer(_connectionStr,
                ctxbuild => ctxbuild.MigrationsAssembly(typeof(ServiceDbContext).Assembly.FullName));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ServiceDbContext).Assembly);
        }
    }
}
