using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class ProfileServices : IProfileService
    {
        public ProfileServices()
        {

        }
        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var claims = context.Subject.FindAll(JwtClaimTypes.Role);
            context.IssuedClaims.AddRange(claims);
            return Task.CompletedTask;
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            return Task.CompletedTask;
        }
    }
}
