using HRMS.Domain.Common;

namespace HRMS.Domain.Entities.Organization
{
    public class Branch : BaseEntity
    {
        public Guid CompanyId { get; set; } // Foreign key to the Company entity
        public string Name { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
       public bool IsHeadOffice { get; set; }
        public bool IsActive { get; set; } = true; // Indicates whether the branch is active
        public Company Company { get; set; } = null!; // Navigation property for the related company
    }
}
