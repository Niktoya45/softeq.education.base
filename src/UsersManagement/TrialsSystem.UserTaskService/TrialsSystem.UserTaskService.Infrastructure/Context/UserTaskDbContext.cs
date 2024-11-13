using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;
using TrialsSystem.UserTaskService.Domain.AggregatesModel.UserTaskAggregate;

namespace TrialsSystem.UserTaskService.Infrastructure.Context
{
    public class UserTaskDbContext : DbContext
    {
        public IMongoDatabase _mongodb { get; private set; }
        public IMongoCollection<UserTask> UserTasks { get; private set; }

        public UserTaskDbContext(DbContextOptions opts, DbContextConfig cfg) : base(opts)
        {
            _mongodb = new MongoClient(cfg.ConnectionString).GetDatabase(cfg.DatabaseName);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbctxob)
        {

            dbctxob.UseMongoDB(_mongodb.Client, _mongodb.DatabaseNamespace.DatabaseName);

            UserTasks = _mongodb.GetCollection<UserTask>("UserTasks");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserTask>().ToCollection("UserTasks");
        }
    }
}
