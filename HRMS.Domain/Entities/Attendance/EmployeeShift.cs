using HRMS.Domain.Common;


namespace HRMS.Domain.Entities.Attendance
{
    public class EmployeeShift : BaseEntity
    {
        public Guid EmployeeId { get; set; }
        public Guid ShiftId { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }

        public HRMS.Domain.Entities.Employee.Employee Employee { get; set; } = null!;
        public Shift Shift { get; set; } = null!;
    }
}
