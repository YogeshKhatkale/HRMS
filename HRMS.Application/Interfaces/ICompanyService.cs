using HRMS.Application.DTOs;

namespace HRMS.Application.Interfaces;

public interface ICompanyService
{
    Task<CompanyResponseDto> CreateAsync(CreateCompanyDto dto);
    Task<IEnumerable<CompanyResponseDto>> GetAllAsync();
    Task<CompanyResponseDto?> GetByIdAsync(Guid id);
}