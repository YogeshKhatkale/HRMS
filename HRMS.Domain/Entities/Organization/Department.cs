using HRMS.Domain.Common;

namespace HRMS.Domain.Entities.Organization;

public class Department : BaseEntity
{
    public Guid CompanyId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public Guid? ParentDeptId { get; set; }
    public Guid? ManagerId { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;

    // Navigation
    public Company Company { get; set; } = null!;
    public Department? ParentDepartment { get; set; }
    public ICollection<Department> SubDepartments { get; set; } = new List<Department>();
    public ICollection<Designation> Designations { get; set; } = new List<Designation>();
    public ICollection<HRMS.Domain.Entities.Employee.Employee> Employees { get; set; } = new List<HRMS.Domain.Entities.Employee.Employee>();
}