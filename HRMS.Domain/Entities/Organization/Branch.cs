using HRMS.Domain.Common;

namespace HRMS.Domain.Entities.Organization;

public class Branch : BaseEntity
{
    public Guid CompanyId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public bool IsHeadOffice { get; set; } = false;
    public bool IsActive { get; set; } = true;

    // Navigation
    public Company Company { get; set; } = null!;
    public ICollection<HRMS.Domain.Entities.Employee.Employee> Employees { get; set; } = new List<HRMS.Domain.Entities.Employee.Employee>();
}