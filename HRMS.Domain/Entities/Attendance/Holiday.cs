using HRMS.Domain.Common;

namespace HRMS.Domain.Entities.Attendance
{
    public class Holiday : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Type { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}
