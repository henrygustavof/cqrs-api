using Project.Domain.Constants;
using System.Security.Claims;

namespace Project.API.Helpers
{
    public static class UserHelpers
    {
        public static string GetUserName(this ClaimsPrincipal principal)
        {
            var userIdClaim = principal.FindFirst(c => c.Type == ClaimTypes.NameIdentifier) ?? principal.FindFirst(c => c.Type == ClaimConstants.Sub);
            if (userIdClaim != null && !string.IsNullOrEmpty(userIdClaim.Value))
            {
                return userIdClaim.Value;
            }

            return string.Empty;
        }

        public static string GetRole(this ClaimsPrincipal principal)
        {
            var userRoleClaim = principal.FindFirst(c => c.Type == ClaimTypes.Role) ?? principal.FindFirst(c => c.Type == ClaimConstants.Role);
            if (userRoleClaim != null && !string.IsNullOrEmpty(userRoleClaim.Value))
            {
                return userRoleClaim.Value;
            }

            return string.Empty;
        }

        public static string GetDocNumber(this ClaimsPrincipal principal)
        {
            var docNumberClaim = principal.FindFirst(c => c.Type == ClaimConstants.DocNumber);
            if (docNumberClaim != null && !string.IsNullOrEmpty(docNumberClaim.Value))
            {
                return docNumberClaim.Value;
            }

            return string.Empty;
        }

        public static bool IsAdmin(this ClaimsPrincipal principal)
        {
            var userRoleClaim = principal.FindFirst(c => c.Type == ClaimTypes.Role) ?? principal.FindFirst(c => c.Type == ClaimConstants.Role);
            if (userRoleClaim != null && !string.IsNullOrEmpty(userRoleClaim.Value))
            {
                return userRoleClaim.Value == RoleConstants.Admin;
            }

            return false;
        }
    }
}
