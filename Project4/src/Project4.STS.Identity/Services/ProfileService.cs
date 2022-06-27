using Duende.IdentityServer.AspNetIdentity;
using Duende.IdentityServer.Models;

using IdentityModel;

using Microsoft.AspNetCore.Identity;

using Project4.Admin.EntityFramework.Shared.Entities.Identity;

using System.Threading.Tasks;

namespace Project4.STS.Identity.Services
{
    public class ProfileService : ProfileService<UserIdentity>
    {
        public ProfileService(UserManager<UserIdentity> userManager, IUserClaimsPrincipalFactory<UserIdentity> claimsFactory) : base(userManager, claimsFactory)
        {
        }

        public override async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            await base.GetProfileDataAsync(context);

            var roleClaims = context.Subject.FindAll(JwtClaimTypes.Role);
            context.IssuedClaims.AddRange(roleClaims);
        }

        public override Task IsActiveAsync(IsActiveContext context)
        {
            return base.IsActiveAsync(context);
        }
    }
}
