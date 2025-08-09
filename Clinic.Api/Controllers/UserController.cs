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
        try
        {
            var token = await _svc.LoginAsync(dto);
            return Ok(new { Token = token });
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { Message = ex.Message });
        }
    }

    [Authorize]
    [HttpGet("getAll")] public async Task<IActionResult> GetAll() => Ok(await _svc.GetAllAsync());

    [Authorize]
    [HttpGet("getById/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var u = await _svc.GetByIdAsync(id);
        return u is null ? NotFound() : Ok(u);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("deleteUser/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _svc.DeleteAsync(id);
        if (!result)
            return NotFound();

        return NoContent();
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("create")]
    public async Task<IActionResult> CreateUser(CreateUserDto dto)
    {
        try
        {
            var userId = await _svc.CreateUserAsync(dto);
            return Ok(new { UserId = userId });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("update")]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto dto)
    {
        var result = await _svc.UpdateUserAsync(dto);
        if (!result)
            return NotFound("User not found.");

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