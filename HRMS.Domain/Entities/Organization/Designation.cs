using HRMS.Domain.Common;

namespace HRMS.Domain.Entities.Organization;

public class Designation : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public Guid DepartmentId { get; set; }
    public string? Grade { get; set; }
    public bool IsActive { get; set; } = true;

    // Navigation
    public Department Department { get; set; } = null!;
    public ICollection<HRMS.Domain.Entities.Employee.Employee> Employees { get; set; } = new List<HRMS.Domain.Entities.Employee.Employee>();
}