using Clinic.Api.Application.DTOs.Users;
using Clinic.Api.Application.Interfaces;
using Clinic.Api.Domain.Entities;

namespace Clinic.Api.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly ITokenService _token;

        public UserService(IUnitOfWork uow, ITokenService token)
        {
            _uow = uow;
            _token = token;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync() =>
            (await _uow.Users.GetAllAsync()).Select(u => new UserDto
            {
                Id = u.Id,
                Email = u.Email,
                FirstName = u.FirstName,
                LastName = u.LastName,
                RoleId = u.RoleId
            });

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var u = await _uow.Users.GetByIdAsync(id);
            return u is null ? null : new UserDto
            {
                Id = u.Id,
                Email = u.Email,
                FirstName = u.FirstName,
                LastName = u.LastName,
                RoleId = u.RoleId
            };
        }

        public async Task<int> RegisterAsync(RegisterUserDto dto)
        {
            var user = new UserContext
            {
                Email = dto.Email,
                Password = dto.Password,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                RoleId = dto.RoleId,
                IsActive = true
            };
            await _uow.Users.AddAsync(user);
            await _uow.SaveAsync();
            return user.Id;
        }

        public async Task<string?> LoginAsync(LoginUserDto dto)
        {
            var user = (await _uow.Users.GetAllAsync())
                .FirstOrDefault(u => u.Email == dto.Email && u.Password == dto.Password);

            return user is null ? null : _token.CreateToken(user);
        }

        public async Task<bool> AssignRoleAsync(int userId, int roleId)
        {
            var user = await _uow.Users.GetByIdAsync(userId);
            if (user == null) return false;

            user.RoleId = roleId;
            await _uow.SaveAsync();
            return true;
        }
    }
}
