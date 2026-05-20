using HRMS.Domain.Common;
namespace HRMS.Domain.Entities.Payroll
{
    public class Payslip : BaseEntity
    {
        public Guid PayrollRunId { get; set; }
        public Guid EmployeeId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int WorkingDays { get; set; }
        public decimal PresentDays { get; set; }
        public decimal? LeaveDays { get; set; }
        public decimal? AbsentDays { get; set; }
        public decimal GrossSalary { get; set; }
        public decimal TotalEarnings { get; set; }
       
        public decimal TotalDeductions { get; set; }
        public decimal NetSalary { get; set; }
        public string Status { get; set; } = "Generated";
        public DateTime? PaidAt { get; set; }

        public PayrollRun PayrollRun { get; set; } = null!;
        public HRMS.Domain.Entities.Employee.Employee Employee { get; set; } = null!;
        public ICollection<PayslipComponent> Components { get; set; } = new List<PayslipComponent>();


    }
}
