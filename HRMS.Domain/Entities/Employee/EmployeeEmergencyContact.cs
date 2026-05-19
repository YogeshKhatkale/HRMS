using HRMS.Domain.Common;

namespace HRMS.Domain.Entities.Employee
{
    public class EmployeeEmergencyContact : BaseEntity
    {
        public Guid EmployeeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Relationship { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? AlternatePhone {  get; set; }

        public Employee Employee { get; set; } = null!;
    }
}
