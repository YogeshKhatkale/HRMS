using Microsoft.AspNetCore.Identity;

namespace HRMS.Domain.Entities.Identity;

public class ApplicationUser : IdentityUser<Guid>
{
    public bool IsActive { get; set; } = true;
    public bool IsDeleted { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    // Navigation
    public HRMS.Domain.Entities.Employee.Employee? Employee { get; set; }
}