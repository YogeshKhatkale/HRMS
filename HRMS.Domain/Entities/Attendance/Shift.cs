using HRMS.Domain.Common;

namespace HRMS.Domain.Entities.Attendance
{
    public class Shift : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public decimal WorkingHours { get; set; }
        public bool Isfxelible { get; set; } = false;
        public bool IsActive {  get; set; } = true ;

    }
}
