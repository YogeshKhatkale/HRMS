using HRMS.Domain.Common;

namespace HRMS.Domain.Entities.Employee
{
    public class EmployeeBankDetail : BaseEntity
    {

        public Guid EmployeeId { get; set; }
        public string BankName { get; set; } = string.Empty;
        public string AccountNumber { get; set; } = string.Empty;
        public string AccountTitle { get; set; } = string.Empty;
        public string? BranchName { get; set; }
        public string? IFSCCode { get; set; }
        public bool IsPrimary { get; set; }

        public Employee Employee { get; set; } = null!;

    }
}
