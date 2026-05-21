using HRMS.Application.DTOs;
using HRMS.Application.Interfaces;
using HRMS.Domain.Entities.Organization;
using HRMS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Infrastructure.Services;

public class CompanyService : ICompanyService
{
    private readonly HRMSDbContext _context;

    public CompanyService(HRMSDbContext context)
    {
        _context = context;
    }

    public async Task<CompanyResponseDto> CreateAsync(CreateCompanyDto dto)
    {
        var company = new Company
        {
            Name = dto.Name,
            Address = dto.Address,
            Phone = dto.Phone,
            Email = dto.Email,
            Website = dto.Website,
            TaxNumber = dto.TaxNumber,
            IsActive = true
        };

        _context.Companies.Add(company);
        await _context.SaveChangesAsync();

        return await GetByIdAsync(company.Id)
            ?? throw new Exception("Failed to retrieve created company");
    }

    public async Task<IEnumerable<CompanyResponseDto>> GetAllAsync()
    {
        return await _context.Companies
            .Where(c => !c.IsDeleted)
            .Select(c => new CompanyResponseDto
            {
                Id = c.Id,
                Name = c.Name,
                Address = c.Address,
                Phone = c.Phone,
                Email = c.Email,
                Website = c.Website,
                IsActive = c.IsActive,
                CreatedAt = c.CreatedAt
            })
            .ToListAsync();
    }

    public async Task<CompanyResponseDto?> GetByIdAsync(Guid id)
    {
        var company = await _context.Companies
            .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);

        if (company == null) return null;

        return new CompanyResponseDto
        {
            Id = company.Id,
            Name = company.Name,
            Address = company.Address,
            Phone = company.Phone,
            Email = company.Email,
            Website = company.Website,
            IsActive = company.IsActive,
            CreatedAt = company.CreatedAt
        };
    }
}