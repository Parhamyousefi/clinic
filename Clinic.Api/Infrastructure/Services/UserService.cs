using Azure.Core;
using Clinic.Api.Application.DTOs.Users;
using Clinic.Api.Application.Interfaces;
using Clinic.Api.Domain.Entities;
using Clinic.Api.Infrastructure.Data;
using Clinic.Api.Middlwares;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Api.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly ITokenService _token;
        private readonly ApplicationDbContext _context;
        private readonly IPasswordHasher<UserContext> _passwordHasher;

        public UserService(IUnitOfWork uow, ITokenService token, ApplicationDbContext context, IPasswordHasher<UserContext> passwordHasher)
        {
            _uow = uow;
            _token = token;
            _context = context;
            _passwordHasher = passwordHasher;
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
            try
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<LoginResponseDto> LoginAsync(LoginUserDto dto)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Username);
                if (user == null ||
                    _passwordHasher.VerifyHashedPassword(user, user.Password, dto.Password) != PasswordVerificationResult.Success)
                    throw new UnauthorizedAccessException("Invalid username or password.");

                var roleName = await _context.Roles
      .Where(r => r.Id == user.RoleId)
      .Select(r => r.Name)
      .FirstOrDefaultAsync() ?? string.Empty;

                var token = _token.CreateToken(user, roleName);
                var roleHandler = UserMapper.MapRole(user.RoleId.ToString());
                string secret = roleHandler[1];
                return new LoginResponseDto
                {
                    Token = token,
                    SecretCode = secret
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var user = await _uow.Users.GetByIdAsync(id);
                if (user == null) return false;

                _context.Users.Remove(user);
                await _uow.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> AssignRoleAsync(int userId, int roleId)
        {
            try
            {
                var user = await _uow.Users.GetByIdAsync(userId);
                if (user == null) return false;

                user.RoleId = roleId;
                await _uow.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> CreateUserAsync(CreateUserDto dto)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateUserAsync(UpdateUserDto dto)
        {
            try
            {
                var user = await _uow.Users.GetByIdAsync(dto.Id);
                if (user == null) throw new Exception("User Not Exists");

                if (!string.IsNullOrEmpty(dto.Username))
                    user.Email = dto.Username;

                if (!string.IsNullOrEmpty(dto.FirstName))
                    user.FirstName = dto.FirstName;

                if (!string.IsNullOrEmpty(dto.LastName))
                    user.LastName = dto.LastName;

                if (dto.RoleId.HasValue)
                    user.RoleId = dto.RoleId.Value;

                if (dto.IsActive.HasValue)
                    user.IsActive = dto.IsActive.Value;

                if (!string.IsNullOrEmpty(dto.Password))
                {
                    // Assuming you have IPasswordHasher<User> injected
                    user.Password = _passwordHasher.HashPassword(user, dto.Password);
                }

                _context.Users.Update(user);
                await _uow.SaveAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> ForgotPasswordAsync(ForgotPasswordDto dto)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Username);
                if (user == null)
                    throw new Exception("User not found");

                user.Password = _passwordHasher.HashPassword(user, dto.NewPassword);
                _context.Users.Update(user);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
