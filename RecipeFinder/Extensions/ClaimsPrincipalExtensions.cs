using System.Security.Claims;
using static RecipeFinder.Core.Constants.RoleConstants;

namespace RecipeFinder.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        // Id method is used to get the user's Id from the ClaimsPrincipal object
        public static string Id(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        // IsAdmin method is used to check if the user is an admin
        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            return user.IsInRole(AdminRole);
        }
    }
}
