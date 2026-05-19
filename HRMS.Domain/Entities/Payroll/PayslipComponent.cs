using HRMS.Domain.Common;
namespace HRMS.Domain.Entities.Payroll
{
    public class PayslipComponent : BaseEntity
    {
        public Guid PayslipId { get; set; }
        public Guid ComponentId { get; set; }
        public string ComponentName { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public decimal Amount { get; set; }

        public Payslip payslip { get; set; } = null!;
    }
}
