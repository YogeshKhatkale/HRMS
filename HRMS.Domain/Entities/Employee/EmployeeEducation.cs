using HRMS.Domain.Common;

namespace HRMS.Domain.Entities.Employee
{
    public class EmployeeEducation : BaseEntity
    {
        public Guid EmployeeId { get; set; }
        public string Degree { get; set; } = string.Empty;
        public string Institute {  get; set; } = string.Empty;
        public string? FieldOfStudy {  get; set; }
        public int? StartYear { get; set; }
        public int? EndYear { get; set; }
        public string? Grade { get; set; }

        public Employee Employee { get; set; } = null!;
    }
}
