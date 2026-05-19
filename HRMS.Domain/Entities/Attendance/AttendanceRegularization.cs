using HRMS.Domain.Common;

namespace HRMS.Domain.Entities.Attendance
{
    public class AttendanceRegularization : BaseEntity
    {
        public Guid EmployeeId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public DateTime? RequestedIn { get; set; }
        public DateTime? RequestedOut { get; set; }
        public string Reason { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending";
        public Guid? ApprovedBy { get; set; } 
        public DateTime? ApprovedAt { get; set; }
        public string? RejectionReason { get; set; }

        public HRMS.Domain.Entities.Employee.Employee Employee { get; set; } = null!;
    }
}
