using Clinic.Api.Domain.Entities;

namespace Clinic.Api.Application.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(UserContext user);
    }
}
