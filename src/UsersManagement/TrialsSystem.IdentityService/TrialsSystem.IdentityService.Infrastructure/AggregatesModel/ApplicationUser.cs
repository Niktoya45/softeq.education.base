using Microsoft.AspNetCore.Identity;

namespace TrialsSystem.IdentityService.Infrastructure.AggregatesModel
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base()
        {
        }
        public ApplicationUser(string userName) : base(userName)
        {
        }
    }
}