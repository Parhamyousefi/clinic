using Clinic.Api.Application.DTOs.UserDto.UserDto;
using Clinic.Api.Application.DTOs.Users;
using Clinic.Api.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _svc;
    public UserController(IUserService svc) => _svc = svc;

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserDto dto) =>
        Ok(await _svc.RegisterAsync(dto));

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserDto dto)
    {
        var token = await _svc.LoginAsync(dto);
        return token is null ? Unauthorized() : Ok(token);
    }

    [Authorize]
    [HttpGet] public async Task<IActionResult> GetAll() => Ok(await _svc.GetAllAsync());

    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var u = await _svc.GetByIdAsync(id);
        return u is null ? NotFound() : Ok(u);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var user = await _svc.GetByIdAsync(id);
        if (user is null) return NotFound();
        return NoContent();
    }

    [HttpPut("assign-role")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AssignRoleToUser(AssignRoleDto dto)
    {
        var result = await _svc.AssignRoleAsync(dto.UserId, dto.RoleId);
        return result ? Ok("Role assigned successfully.") : NotFound("User not found.");
    }
}