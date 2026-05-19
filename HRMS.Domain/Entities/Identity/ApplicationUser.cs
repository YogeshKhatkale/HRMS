using Microsoft.AspNetCore.Identity;

namespace HRMS.Domain.Entities.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public bool IsActive { get; set; } = true; // Indicates whether the user account is active
        public bool IsDeleted { get; set; } = false; // Soft delete flag, default to false
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Set the creation time to the current UTC time
        public DateTime? UpdatedAt { get; set; } // Nullable, as it may not be updated yet
    }
}
