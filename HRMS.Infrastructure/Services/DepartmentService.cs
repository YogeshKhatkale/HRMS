using HRMS.Application.DTOs;
using HRMS.Application.Interfaces;
using HRMS.Domain.Entities.Organization;
using HRMS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Infrastructure.Services;

public class DepartmentService : IDepartmentService
{
    private readonly HRMSDbContext _context;

    public DepartmentService(HRMSDbContext context)
    {
        _context = context;
    }

    public async Task<DepartmentResponseDto> CreateAsync(CreateDepartmentDto dto)
    {
        // Check duplicate code
        var exists = await _context.Departments
            .AnyAsync(d => d.Code == dto.Code && !d.IsDeleted);
        if (exists)
            throw new Exception($"Department with code '{dto.Code}' already exists");

        var department = new Department
        {
            CompanyId = dto.CompanyId,
            Name = dto.Name,
            Code = dto.Code.ToUpper(),
            ParentDeptId = dto.ParentDeptId,
            ManagerId = dto.ManagerId,
            Description = dto.Description,
            IsActive = true
        };

        _context.Departments.Add(department);
        await _context.SaveChangesAsync();

        return await GetByIdAsync(department.Id)
            ?? throw new Exception("Failed to retrieve created department");
    }

    public async Task<DepartmentResponseDto?> GetByIdAsync(Guid id)
    {
        var dept = await _context.Departments
            .Include(d => d.ParentDepartment)
            .FirstOrDefaultAsync(d => d.Id == id && !d.IsDeleted);

        if (dept == null) return null;

        return await MapToDto(dept);
    }

    public async Task<IEnumerable<DepartmentResponseDto>> GetAllAsync()
    {
        var departments = await _context.Departments
            .Include(d => d.ParentDepartment)
            .Where(d => !d.IsDeleted)
            .OrderBy(d => d.Name)
            .ToListAsync();

        var result = new List<DepartmentResponseDto>();
        foreach (var dept in departments)
            result.Add(await MapToDto(dept));

        return result;
    }

    public async Task<IEnumerable<DepartmentResponseDto>> GetByCompanyAsync(Guid companyId)
    {
        var departments = await _context.Departments
            .Include(d => d.ParentDepartment)
            .Where(d => d.CompanyId == companyId && !d.IsDeleted)
            .OrderBy(d => d.Name)
            .ToListAsync();

        var result = new List<DepartmentResponseDto>();
        foreach (var dept in departments)
            result.Add(await MapToDto(dept));

        return result;
    }

    public async Task<DepartmentResponseDto> UpdateAsync(Guid id, UpdateDepartmentDto dto)
    {
        var department = await _context.Departments
            .FirstOrDefaultAsync(d => d.Id == id && !d.IsDeleted);

        if (department == null)
            throw new Exception("Department not found");

        department.Name = dto.Name;
        department.Code = dto.Code.ToUpper();
        department.ParentDeptId = dto.ParentDeptId;
        department.ManagerId = dto.ManagerId;
        department.Description = dto.Description;
        department.IsActive = dto.IsActive;
        department.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return await GetByIdAsync(id)
            ?? throw new Exception("Failed to retrieve updated department");
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var department = await _context.Departments
            .FirstOrDefaultAsync(d => d.Id == id && !d.IsDeleted);

        if (department == null) return false;

        // Check if department has employees
        var hasEmployees = await _context.Employees
            .AnyAsync(e => e.DepartmentId == id && !e.IsDeleted);

        if (hasEmployees)
            throw new Exception("Cannot delete department with active employees");

        department.IsDeleted = true;
        department.IsActive = false;
        department.DeletedAt = DateTime.UtcNow;
        department.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return true;
    }

    private async Task<DepartmentResponseDto> MapToDto(Department dept)
    {
        var employeeCount = await _context.Employees
            .CountAsync(e => e.DepartmentId == dept.Id && !e.IsDeleted);

        string? managerName = null;
        if (dept.ManagerId.HasValue)
        {
            var manager = await _context.Employees
                .FirstOrDefaultAsync(e => e.Id == dept.ManagerId.Value);
            if (manager != null)
                managerName = $"{manager.FirstName} {manager.LastName}";
        }

        return new DepartmentResponseDto
        {
            Id = dept.Id,
            Name = dept.Name,
            Code = dept.Code,
            Description = dept.Description,
            IsActive = dept.IsActive,
            ParentDeptId = dept.ParentDeptId,
            ParentDepartmentName = dept.ParentDepartment?.Name,
            ManagerName = managerName,
            EmployeeCount = employeeCount,
            CreatedAt = dept.CreatedAt
        };
    }
}