using HRMS.Application.DTOs;

namespace HRMS.Application.Interfaces;

public interface IDepartmentService
{
    Task<DepartmentResponseDto> CreateAsync(CreateDepartmentDto dto);
    Task<DepartmentResponseDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<DepartmentResponseDto>> GetAllAsync();
    Task<IEnumerable<DepartmentResponseDto>> GetByCompanyAsync(Guid companyId);
    Task<DepartmentResponseDto> UpdateAsync(Guid id, UpdateDepartmentDto dto);
    Task<bool> DeleteAsync(Guid id);
}