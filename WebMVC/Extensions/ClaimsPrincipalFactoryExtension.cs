using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebMVC.Areas.Identity.Models;

namespace WebMVC.Extensions
{
    public class ClaimsPrincipalFactoryExtension : UserClaimsPrincipalFactory<AppUser>
    {
        public ClaimsPrincipalFactoryExtension(
        UserManager<AppUser> userManager,
        IOptions<IdentityOptions> optionsAccessor)
            : base(userManager, optionsAccessor)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(AppUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("FullName", user.FullName));
            return identity;
        }
    }
}
