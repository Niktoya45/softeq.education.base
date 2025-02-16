using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrialsSystem.IdentityService.Infrastructure.AggregatesModel;

namespace TrialsSystem.IdentityService.Infrastructure
{ 
    public sealed class ApplicationUserDbContext:IdentityDbContext<ApplicationUser>
    {
        public static string DefinedIn = Directory.GetCurrentDirectory();
        public ApplicationUserDbContext(DbContextOptions<ApplicationUserDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
