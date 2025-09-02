using Clinic.Api.Application.Interfaces;
using System.IdentityModel.Tokens.Jwt;

namespace Clinic.Api.Infrastructure.Services
{
    public class ReadTokenClaims : IReadTokenClaims
    {
        public int GetUserId()
        {
            HttpContextAccessor context = new HttpContextAccessor();
            var idToken = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var token = new JwtSecurityToken(jwtEncodedString: idToken);

            int userId = Convert.ToInt32(token.Claims.First(x => x.Type == "userId").Value);
            return userId;
        }

        public string GetUserRole()
        {
            HttpContextAccessor context = new HttpContextAccessor();
            var idToken = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var token = new JwtSecurityToken(jwtEncodedString: idToken);

            string userRole = token.Claims.First(x => x.Type == "userRole").Value;
            return userRole;
        }
    }
}
