using HRMS.Application.DTOs;
using HRMS.Application.Interfaces;
using HRMS.Domain.Entities.Organization;
using HRMS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Infrastructure.Services;

public class DesignationService : IDesignationService
{
    private readonly HRMSDbContext _context;

    public DesignationService(HRMSDbContext context)
    {
        _context = context;
    }

    public async Task<DesignationResponseDto> CreateAsync(CreateDesignationDto dto)
    {
        var exists = await _context.Designations
            .AnyAsync(d => d.Code == dto.Code && !d.IsDeleted);
        if (exists)
            throw new Exception($"Designation with code '{dto.Code}' already exists");

        var designation = new Designation
        {
            Name = dto.Name,
            Code = dto.Code.ToUpper(),
            DepartmentId = dto.DepartmentId,
            Grade = dto.Grade,
            IsActive = true
        };

        _context.Designations.Add(designation);
        await _context.SaveChangesAsync();

        return await GetByIdAsync(designation.Id)
            ?? throw new Exception("Failed to retrieve created designation");
    }

    public async Task<DesignationResponseDto?> GetByIdAsync(Guid id)
    {
        var designation = await _context.Designations
            .Include(d => d.Department)
            .FirstOrDefaultAsync(d => d.Id == id && !d.IsDeleted);

        if (designation == null) return null;

        return await MapToDto(designation);
    }

    public async Task<IEnumerable<DesignationResponseDto>> GetAllAsync()
    {
        var designations = await _context.Designations
            .Include(d => d.Department)
            .Where(d => !d.IsDeleted)
            .OrderBy(d => d.Name)
            .ToListAsync();

        var result = new List<DesignationResponseDto>();
        foreach (var d in designations)
            result.Add(await MapToDto(d));

        return result;
    }

    public async Task<IEnumerable<DesignationResponseDto>> GetByDepartmentAsync(Guid departmentId)
    {
        var designations = await _context.Designations
            .Include(d => d.Department)
            .Where(d => d.DepartmentId == departmentId && !d.IsDeleted)
            .OrderBy(d => d.Name)
            .ToListAsync();

        var result = new List<DesignationResponseDto>();
        foreach (var d in designations)
            result.Add(await MapToDto(d));

        return result;
    }

    public async Task<DesignationResponseDto> UpdateAsync(Guid id, UpdateDesignationDto dto)
    {
        var designation = await _context.Designations
            .FirstOrDefaultAsync(d => d.Id == id && !d.IsDeleted);

        if (designation == null)
            throw new Exception("Designation not found");

        designation.Name = dto.Name;
        designation.Code = dto.Code.ToUpper();
        designation.DepartmentId = dto.DepartmentId;
        designation.Grade = dto.Grade;
        designation.IsActive = dto.IsActive;
        designation.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return await GetByIdAsync(id)
            ?? throw new Exception("Failed to retrieve updated designation");
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var designation = await _context.Designations
            .FirstOrDefaultAsync(d => d.Id == id && !d.IsDeleted);

        if (designation == null) return false;

        var hasEmployees = await _context.Employees
            .AnyAsync(e => e.DesignationId == id && !e.IsDeleted);

        if (hasEmployees)
            throw new Exception("Cannot delete designation with active employees");

        designation.IsDeleted = true;
        designation.IsActive = false;
        designation.DeletedAt = DateTime.UtcNow;
        designation.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return true;
    }

    private async Task<DesignationResponseDto> MapToDto(Designation d)
    {
        var employeeCount = await _context.Employees
            .CountAsync(e => e.DesignationId == d.Id && !e.IsDeleted);

        return new DesignationResponseDto
        {
            Id = d.Id,
            Name = d.Name,
            Code = d.Code,
            Grade = d.Grade,
            IsActive = d.IsActive,
            DepartmentId = d.DepartmentId,
            DepartmentName = d.Department?.Name,
            EmployeeCount = employeeCount,
            CreatedAt = d.CreatedAt
        };
    }
}