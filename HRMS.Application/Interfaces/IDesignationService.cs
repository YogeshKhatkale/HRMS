using HRMS.Application.DTOs;

namespace HRMS.Application.Interfaces;

public interface IDesignationService
{
    Task<DesignationResponseDto> CreateAsync(CreateDesignationDto dto);
    Task<DesignationResponseDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<DesignationResponseDto>> GetAllAsync();
    Task<IEnumerable<DesignationResponseDto>> GetByDepartmentAsync(Guid departmentId);
    Task<DesignationResponseDto> UpdateAsync(Guid id, UpdateDesignationDto dto);
    Task<bool> DeleteAsync(Guid id);
}