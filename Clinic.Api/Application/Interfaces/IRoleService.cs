using Clinic.Api.Application.DTOs.Role;

namespace Clinic.Api.Application.Interfaces
{
    public interface IRoleService
    {
        Task<List<RoleDto>> GetAllRolesAsync();
        Task<RoleDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(RoleDto dto);
        Task<bool> UpdateAsync(RoleDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
