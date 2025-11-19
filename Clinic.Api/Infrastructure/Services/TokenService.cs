using Clinic.Api.Application.Interfaces;
using Clinic.Api.Application.JwtAuth.Helpers;
using Clinic.Api.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Clinic.Api.Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly JwtSettings _settings;
        public TokenService(IOptions<JwtSettings> opts) => _settings = opts.Value;

        public string CreateToken(UserContext user, string roleName)
        {
            var tokenHandler = new JsonWebTokenHandler();
            var key = Encoding.ASCII.GetBytes(_settings.Key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
          new Claim("userId", user.Id.ToString()),
          new Claim("username", user.Email ?? ""),
          new Claim("userRole", roleName)
                }),
                IssuedAt = DateTime.Now,
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return token;
        }
    }
}
