using HRMS.Domain.Common;

namespace HRMS.Domain.Entities.Employee
{
    public class EmployeeDocument : BaseEntity
    {
        public Guid EmplolyeeId { get; set; }
        public string DocumentType { get; set; } = string.Empty;
        public string DocumentName { get; set; } = string.Empty;
        public string? DocumentNumber { get; set; }
        public string FilePath { get; set; } = string.Empty;
        public DateTime? ExpiryDate { get; set; }
        public bool IsVerified { get; set; } = false;

        Employee Employee { get; set; } = null!;


    }
}
