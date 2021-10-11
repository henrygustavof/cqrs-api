using Microsoft.AspNetCore.Authentication;
using Okta.Sdk;
using Okta.Sdk.Configuration;
using Project.Domain.Constants;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Project.API.Authorization
{
    public class GroupsToRolesTransformation : IClaimsTransformation
    {
        private readonly OktaClient _client;

        public GroupsToRolesTransformation(string oktaDomain, string apiToken)
        {
            _client = new OktaClient(new OktaClientConfiguration
            {
                OktaDomain = oktaDomain,
                Token = apiToken
            });
        }

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal context)
        {
            var idClaim = context.FindFirst(x => x.Type == ClaimTypes.NameIdentifier);
            if (idClaim == null) return await Task.FromResult(context);
        
            var user = await _client.Users.GetUserAsync(idClaim.Value);
            if (user == null) return await Task.FromResult(context);

            var group = await user.Groups.Where(p=>p.Profile.Name != RoleConstants.Everyone).FirstOrDefaultAsync();

            if (group == null) return context;

            ((ClaimsIdentity)context.Identity).AddClaim(new Claim(ClaimTypes.Role, group.Profile.Name));
            return context;
        }
    }
}
