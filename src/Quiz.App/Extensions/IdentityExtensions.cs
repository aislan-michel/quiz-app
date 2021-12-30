using System.Security.Claims;
using System.Security.Principal;

namespace Quiz.App.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetId(this IIdentity identity)
        {
            var claimsIdentity = identity as ClaimsIdentity;
            var claim = claimsIdentity?.FindFirst(ClaimTypes.Sid);

            return claim?.Value;
        }
    }
}