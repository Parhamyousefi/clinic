using AutoMapper;
using Clinic.Api.Application.DTOs.Users;
using Clinic.Api.Application.Interfaces;
using Clinic.Api.Domain.Entities;
using Clinic.Api.Infrastructure.Data;
using Clinic.Api.Middlwares;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static Clinic.Api.Middlwares.Exceptions;

namespace Clinic.Api.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly ITokenService _token;
        private readonly ApplicationDbContext _context;
        private readonly IPasswordHasher<UserContext> _passwordHasher;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork uow, ITokenService token, ApplicationDbContext context, 
            IPasswordHasher<UserContext> passwordHasher, IHttpContextAccessor httpContextAccessor,
            IMapper mapper)
        {
            _uow = uow;
            _token = token;
            _context = context;
            _passwordHasher = passwordHasher;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
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

        public async Task<LoginResponseDto> LoginAsync(LoginUserDto model)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Username);
                if (user == null ||
                    _passwordHasher.VerifyHashedPassword(user, user.Password, model.Password) != PasswordVerificationResult.Success)
                    throw new InvalidModelData(1009, "Invalid username or password.");

                var roleName = await _context.Roles
      .Where(r => r.Id == user.RoleId)
      .Select(r => r.Name)
      .FirstOrDefaultAsync() ?? string.Empty;

                var token = _token.CreateToken(user, roleName);
                var roleHandler = UserMapper.MapRole(user.RoleId.ToString());
                string secret = roleHandler[1];

                await SaveLoginHistory(model.Username);
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

        public async Task<int> CreateUserAsync(CreateUserDto model)
        {
            try
            {
                var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Username);
                if (existingUser != null)
                    throw new InvalidModelData(1006, "Email already exists.");

                var hasher = new PasswordHasher<object>();
                var hashedPassword = hasher.HashPassword(null, model.Password);

                var user = new UserContext
                {
                    Email = model.Username,
                    Password = hashedPassword,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    RoleId = model.RoleId,
                    IsActive = model.IsActive
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

        public async Task<bool> UpdateUserAsync(UpdateUserDto model)
        {
            try
            {
                var user = await _uow.Users.GetByIdAsync(model.Id);
                if (user == null) throw new NotFoundException(1008, "User Not Exists");

                if (!string.IsNullOrEmpty(model.Username))
                    user.Email = model.Username;

                if (!string.IsNullOrEmpty(model.FirstName))
                    user.FirstName = model.FirstName;

                if (!string.IsNullOrEmpty(model.LastName))
                    user.LastName = model.LastName;

                if (model.RoleId.HasValue)
                    user.RoleId = model.RoleId.Value;

                if (model.IsActive.HasValue)
                    user.IsActive = model.IsActive.Value;

                if (!string.IsNullOrEmpty(model.Password))
                {
                    user.Password = _passwordHasher.HashPassword(user, model.Password);
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

        public async Task<bool> ForgotPasswordAsync(ForgotPasswordDto model)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Username);
                if (user == null)
                    throw new NotFoundException(1007, "User not found");

                var passwordVerification = _passwordHasher.VerifyHashedPassword(user, user.Password, model.OldPassword);
                if (passwordVerification != PasswordVerificationResult.Success)
                    throw new OldPasswordIncorrect(1010, "Old password is incorrect");

                user.Password = _passwordHasher.HashPassword(user, model.NewPassword);
                _context.Users.Update(user);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task SaveLoginHistory (string? Username)
        {
            try
            {
                var ip = GetClientIp();
                var loginHistoryModel = new SaveLoginHistoryDto
                {
                    UserName = Username,
                    Ip = ip,
                    LoginDateTime = DateTime.UtcNow,
                    HostName = ip
                };

                var history = _mapper.Map<LoginHistoriesContext>(loginHistoryModel);
                _context.LoginHistories.Add(history);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GetClientIp()
        {
            var context = _httpContextAccessor.HttpContext;
            if (context == null)
                return "Unknown";

            var forwardedIp = context.Request.Headers["MC-Real-IP"].FirstOrDefault();
            if (!string.IsNullOrEmpty(forwardedIp))
                return forwardedIp;

            return context.Connection.RemoteIpAddress?.ToString() ?? "Unknown";
        }
    }
}
