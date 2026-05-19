using HRMS.Domain.Common;

namespace HRMS.Domain.Entities.Organization
{
    public class Designation : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public Guid DepartmentId { get; set; }
        public string? Grade { get; set; }
        public bool IsActive { get; set; } = true; // Indicates whether the designation is active
        public Department Department { get; set; } = null!; // Navigation property for the related department
    }
}
