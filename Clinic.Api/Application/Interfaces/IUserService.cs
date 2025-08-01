using Clinic.Api.Application.DTOs;

namespace Clinic.Api.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto?> GetByIdAsync(int id);
        Task<int> RegisterAsync(RegisterUserDto dto);
        Task<string?> LoginAsync(LoginUserDto dto);
    }
}
