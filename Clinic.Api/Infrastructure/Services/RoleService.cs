using AutoMapper;
using Clinic.Api.Application.DTOs.Role;
using Clinic.Api.Application.Interfaces;
using Clinic.Api.Domain.Entities;
using Clinic.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class RoleService : IRoleService
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public RoleService(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<List<RoleDto>> GetAllRolesAsync()
    {
        var roles = await _db.Roles.ToListAsync();
        return _mapper.Map<List<RoleDto>>(roles);
    }

    public async Task<RoleDto?> GetByIdAsync(int id)
    {
        var role = await _db.Roles.FindAsync(id);
        return _mapper.Map<RoleDto?>(role);
    }

    public async Task<int> CreateAsync(RoleDto dto)
    {
        var role = _mapper.Map<RoleContext>(dto);
        _db.Roles.Add(role);
        await _db.SaveChangesAsync();
        return role.Id;
    }

    public async Task<bool> UpdateAsync(RoleDto dto)
    {
        var role = await _db.Roles.FindAsync(dto.Id);
        if (role == null) return false;

        role.Name = dto.Name;
        role.Description = dto.Description;
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var role = await _db.Roles.FindAsync(id);
        if (role == null) return false;

        _db.Roles.Remove(role);
        await _db.SaveChangesAsync();
        return true;
    }
}