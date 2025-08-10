using Clinic.Api.Application.DTOs.Users;
using Clinic.Api.Application.Interfaces;
using Clinic.Api.Domain.Entities;
using Clinic.Api.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Api.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly ITokenService _token;
        private readonly ApplicationDbContext _context;

        public UserService(IUnitOfWork uow, ITokenService token, ApplicationDbContext context)
        {
            _uow = uow;
            _token = token;
            _context = context;
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
            var hasher = new PasswordHasher<object>();

            var user = new UserContext
            {
                Email = dto.Email,
                Password = hasher.HashPassword(null, dto.Password),
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
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Username);

            if (user == null || !user.IsActive)
                return null;

            if (!VerifyPassword(dto.Password, user.Password))
                return null;

            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == user.RoleId);
            var roleName = role?.Name ?? "User";

            return _token.CreateToken(user, roleName);
        }

        private bool VerifyPassword(string password, string storedHash)
        {
            try
            {
                var hasher = new PasswordHasher<object>();
                var result = hasher.VerifyHashedPassword(null, storedHash, password);
                return result == PasswordVerificationResult.Success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _uow.Users.GetByIdAsync(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _uow.SaveAsync();
            return true;
        }

        public async Task<bool> AssignRoleAsync(int userId, int roleId)
        {
            var user = await _uow.Users.GetByIdAsync(userId);
            if (user == null) return false;

            user.RoleId = roleId;
            await _uow.SaveAsync();
            return true;
        }

        public async Task<int> CreateUserAsync(CreateUserDto dto)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Username);
            if (existingUser != null)
                throw new ArgumentException("Email already exists.");

            var hasher = new PasswordHasher<object>();
            var hashedPassword = hasher.HashPassword(null, dto.Password);

            var user = new UserContext
            {
                Email = dto.Username,
                Password = hashedPassword,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                RoleId = dto.RoleId,
                IsActive = dto.IsActive
            };

            await _uow.Users.AddAsync(user);
            await _uow.SaveAsync();

            return user.Id;
        }

        public async Task<bool> UpdateUserAsync(UpdateUserDto dto)
        {
            var user = await _uow.Users.GetByIdAsync(dto.Id);
            if (user == null) return false;

            if (!string.IsNullOrEmpty(dto.Email))
                user.Email = dto.Email;

            if (!string.IsNullOrEmpty(dto.FirstName))
                user.FirstName = dto.FirstName;

            if (!string.IsNullOrEmpty(dto.LastName))
                user.LastName = dto.LastName;

            if (dto.RoleId.HasValue)
                user.RoleId = dto.RoleId.Value;

            if (dto.IsActive.HasValue)
                user.IsActive = dto.IsActive.Value;

            _context.Users.Update(user);
            await _uow.SaveAsync();

            return true;
        }
    }
}
