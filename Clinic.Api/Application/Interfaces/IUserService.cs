using Clinic.Api.Application.DTOs.Users;
using Clinic.Api.Domain.Entities;

namespace Clinic.Api.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto?> GetByIdAsync(int id);
        Task<LoginResponseDto> LoginAsync(LoginUserDto loginDto);
        Task<bool> DeleteAsync(int id);
        Task<bool> AssignRoleAsync(int userId, int roleId);
        Task<int> CreateUserAsync(CreateUserDto model);
        Task<bool> UpdateUserAsync(UpdateUserDto model);
        Task<bool> ForgotPasswordAsync(ForgotPasswordDto model);
        Task<IEnumerable<UserContext>> GetUsers(int roleId);
    }
}
