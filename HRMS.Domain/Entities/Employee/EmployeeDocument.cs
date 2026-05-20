using HRMS.Domain.Common;

namespace HRMS.Domain.Entities.Employee;

public class EmployeeDocument : BaseEntity
{
    public Guid EmployeeId { get; set; }
    public string DocumentType { get; set; } = string.Empty;
    public string DocumentName { get; set; } = string.Empty;
    public string? DocumentNumber { get; set; }
    public string FilePath { get; set; } = string.Empty;
    public DateTime? ExpiryDate { get; set; }
    public bool IsVerified { get; set; } = false;

    public Employee Employee { get; set; } = null!;
}