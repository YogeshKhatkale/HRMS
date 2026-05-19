using  HRMS.Domain.Common;

namespace HRMS.Domain.Entities.Organization
{
    public class Company : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Logo { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public string? TaxNumber { get; set; }
        public bool IsActive { get; set; } = true; // Indicates whether the company is active

        public ICollection<Branch> Branches { get; set; } = new List<Branch>(); // Navigation property for related branches
        public ICollection<Department> Departments { get; set; } = new List<Department>(); // Navigation property for related departments
    }
}
