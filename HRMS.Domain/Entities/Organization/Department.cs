using HRMS.Domain.Common;

namespace HRMS.Domain.Entities.Organization
{
    public class Department : BaseEntity
    {
        public Guid CompanyId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public Guid? ParentDeptId { get; set; } // Nullable, as it may not have a parent department
        public Guid? ManagerId { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true; // Indicates whether the department is active

        public Company Company { get; set; } = null!; // Navigation property for the related company
        public Department? ParentDepartment { get; set; } // Navigation property for the parent department
        public ICollection<Department> SubDepartments { get; set; } = new List<Department>(); // Navigation property for related sub-departments
        public ICollection<Designation> Designations { get; set; } = new List<Designation>(); // Navigation property for related designations
    }
}
