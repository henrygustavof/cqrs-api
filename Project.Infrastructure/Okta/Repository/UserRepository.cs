using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Okta.Sdk;
using Okta.Sdk.Configuration;
using Project.Domain.Constants;
using Project.Domain.Repository;

namespace Project.Infrastructure.Okta.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly OktaClient _client;

        public UserRepository(string oktaDomain, string apiToken)
        {
            _client = new OktaClient(new OktaClientConfiguration
            {
                OktaDomain = oktaDomain,
                Token = apiToken
            });
        }

        public async Task<IEnumerable<Domain.Entity.User>> GetAllByFilterParamsAsync(string docNumber = "")
        {
            var groups =  await _client.Groups.ListGroups().ToArrayAsync();

            var memberGroup = groups.FirstOrDefault(group => @group.Profile.Name == RoleConstants.Member);

            var users =  _client.Groups.ListGroupUsers(memberGroup.Id);

            var response = users.Select( user => new Domain.Entity.User
            {
                DocNumber = user.Profile?.EmployeeNumber ?? string.Empty,
                UserName = user.Profile.Email,
                FullName = $"{user.Profile.FirstName} {user.Profile.LastName}",
                Status = user.Status.Value,
                Address = user.Profile.StreetAddress
            });

            return string.IsNullOrEmpty(docNumber)
                ? await response.ToListAsync()
                : await response.Where(user => user.DocNumber.Contains(docNumber)).ToListAsync();
        }

        public async Task<Domain.Entity.User> GetByUserNameAsync(string userName)
        {
            var user = await _client.Users.GetUserAsync(userName);

            return new Domain.Entity.User
            {
                DocNumber = user.Profile?.EmployeeNumber ?? string.Empty,
                UserName = user.Profile.Email,
                FullName = $"{user.Profile.FirstName} {user.Profile.LastName}",
                Status = user.Status.Value,
                Address = user.Profile.StreetAddress
            };
        }
    }
}
