namespace Clinic.Api.Application.Interfaces
{
    public interface IReadTokenClaims
    {
        int GetUserId();
        string GetUserRole();
    }
}
