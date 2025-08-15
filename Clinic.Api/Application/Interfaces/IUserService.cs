using Clinic.Api.Application.DTOs.Users;

namespace Clinic.Api.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto?> GetByIdAsync(int id);
        Task<LoginResponseDto> LoginAsync(LoginUserDto loginDto);
        Task<bool> DeleteAsync(int id);
        Task<bool> AssignRoleAsync(int userId, int roleId);
        Task<int> CreateUserAsync(CreateUserDto dto);
        Task<bool> UpdateUserAsync(UpdateUserDto dto);
        Task<string> ForgotPasswordAsync(ForgotPasswordDto dto);
    }
}
