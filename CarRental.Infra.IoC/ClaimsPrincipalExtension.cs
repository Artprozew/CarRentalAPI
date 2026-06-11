using System.Security.Claims;

namespace CarRental.Infra.IoC
{
    public static class ClaimsPrincipalExtension
    {
        public static int? GetId(this ClaimsPrincipal user)
        {
            Claim? userId = user.FindFirst("id");
            return userId == null ? null : int.Parse(userId.Value);
        }

        public static string GetEmail(this ClaimsPrincipal user)
        {
            return user.FindFirst("email").Value;
        }
    }
}
