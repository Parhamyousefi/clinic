using Clinic.Api.Application.DTOs.Role;
using Clinic.Api.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll()
    {
        var roles = await _roleService.GetAllRolesAsync();
        return Ok(roles);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Get(int id)
    {
        var role = await _roleService.GetByIdAsync(id);
        return role == null ? NotFound() : Ok(role);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(RoleDto dto)
    {
        var id = await _roleService.CreateAsync(dto);
        return CreatedAtAction(nameof(Get), new { id }, dto);
    }

    [HttpPut]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(RoleDto dto)
    {
        var result = await _roleService.UpdateAsync(dto);
        return result ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _roleService.DeleteAsync(id);
        return result ? NoContent() : NotFound();
    }
}