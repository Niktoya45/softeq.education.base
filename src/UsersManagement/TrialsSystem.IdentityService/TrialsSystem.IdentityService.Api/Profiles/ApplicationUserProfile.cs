using Microsoft.AspNetCore.Identity;
using IdentityServer4.Services;
using TrialsSystem.IdentityService.Infrastructure.AggregatesModel;
using IdentityServer4.Models;
using IdentityModel;
using System.Security.Claims;

namespace TrialsSystem.IdentityService.Api.Profiles
{
    public class ApplicationUserProfile:IProfileService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public ApplicationUserProfile(UserManager<ApplicationUser> userManager) 
        {
            _userManager = userManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var user = await _userManager.GetUserAsync(context.Subject);
            IList<Claim>?  claims = await _userManager.GetClaimsAsync(user);
            IList<string>? role_names = await _userManager.GetRolesAsync(user);

            string roles_string = String.Join(",", role_names);
            Claim roles_claim = new Claim(JwtClaimTypes.Role, roles_string);

            claims.Add(roles_claim);

            context.IssuedClaims.Add(roles_claim);
        }

        public async Task IsActiveAsync(IsActiveContext context) 
        {
            await Task.CompletedTask;
        }
    }
}
