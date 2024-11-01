using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using TrialsSystem.UserTaskService.Domain.AggregatesModel.UserTaskAggregate;

namespace TrialsSystem.UserTaskService.Infrastructure.Context
{
    public class UserTaskDbContext:DbContext
    {   
        public DbSet<UserTask> UserTasks { get; init; }

        private readonly string _connectionStr = @"mongodb://localhost:27017";

        public UserTaskDbContext(DbContextOptions opts):base(opts) { }

        protected override void OnConfiguring(DbContextOptionsBuilder dbctxob) {

            dbctxob.UseMongoDB(_connectionStr, "user_tasks_db");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserTask>().ToCollection("userTasks");
        }
    }
}
