using HRMS.Domain.Common;

namespace HRMS.Domain.Entities.Employee
{
    public class EmployeeExperience : BaseEntity
    {
        public Guid EmployeeId { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string Designation {  get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? ReasonOfLeaving { get; set; }
        public bool IsCurrentJob { get; set; } = false;

        public Employee Employee { get; set; } = null!;
    }
}
