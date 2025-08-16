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

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserDto dto)
    {
        try
        {
            var result = await _svc.LoginAsync(dto);
            return Ok(result);
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { Message = ex.Message });
        }
    }

    [Authorize]
    [HttpGet("getAllUsers")] 
    public async Task<IActionResult> GetAll() => Ok(await _svc.GetAllAsync());

    [Authorize]
    [HttpGet("getUserById/{id}")]
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
    [HttpPost("createUser")]
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
    [HttpPut("updateUser")]
    public async Task<IActionResult> UpdateUser(UpdateUserDto dto)
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

    [HttpPost("forgot-password")]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordDto dto)
    {
        var result = await _svc.ForgotPasswordAsync(dto);
        return Ok(new { success = result, message = "Password updated successfully" });
    }
}