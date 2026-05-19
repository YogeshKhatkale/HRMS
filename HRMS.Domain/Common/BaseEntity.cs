using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid(); // Automatically generate a new GUID for each entity
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Set the creation time to the current UTC time
        public DateTime? UpdatedAt { get; set; } // Nullable, as it may not be updated yet
        public Guid? CreatedBy { get; set; } // Nullable, as it may not be set yet
        public bool IsDeleted { get; set; } = false; // Soft delete flag, default to false
        public DateTime? DeletedAt { get; set; } // Nullable, as it may not be deleted yet
        public Guid? DeletedBy { get; set; } // Nullable, as it may not be set yet
    }
}
