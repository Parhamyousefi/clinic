using Clinic.Api.Application.Interfaces;
using static Clinic.Api.Middlwares.Exceptions;

namespace Clinic.Api.Infrastructure.Services
{
    public class ReadTokenClaims : IReadTokenClaims
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ReadTokenClaims(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int GetUserId()
        {
            var user = _httpContextAccessor.HttpContext?.User;

            if (user == null)
                throw new UnAuthorizedException(1004, "User is not authenticated.");

            var userIdClaim = user.FindFirst("userId");

            if (userIdClaim == null)
                throw new ClaimNotFound(1005, "UserId claim not found in token.");

            return int.Parse(userIdClaim.Value);
        }

        public string GetUserRole()
        {
            var user = _httpContextAccessor.HttpContext?.User;

            if (user == null)
                throw new UnAuthorizedException(1004, "User Is Not Authenticated");

            var userRoleClaim = user.FindFirst("role");

            if (userRoleClaim == null)
                throw new ClaimNotFound(1005, "UserRole Claim Not Found In Token");

            return userRoleClaim.Value;
        }
    }
}
