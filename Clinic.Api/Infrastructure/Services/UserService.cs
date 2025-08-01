using AutoMapper;
using Clinic.Api.Application.DTOs;
using Clinic.Api.Application.Interfaces;
using Clinic.Api.Domain.Entities;
using Clinic.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
    }
}
