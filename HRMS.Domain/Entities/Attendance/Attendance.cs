using HRMS.Domain.Common;

namespace HRMS.Domain.Entities.Attendance
{
    public class Attendance : BaseEntity
    {
        public Guid EmployeeId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get;set; }
        public decimal? WorkedHours { get; set; }
        public string Status { get; set; } = string.Empty;
        public bool IsLate { get; set; }= false;
        public int? LateMinutes { get; set; }
        public string? Remark { get; set; }
        public bool IsManual { get; set; } = false;

        public HRMS.Domain.Entities.Employee.Employee Employee { get; set; } = null!;
    }
}
