using HRMS.Domain.Common;
namespace HRMS.Domain.Entities.Payroll
{
    public class PayrollRun : BaseEntity
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public string Status { get; set; } = "Draft";
        public DateTime? ProcessAt { get; set; }
        public Guid? ProcessedBy { get; set; }
        public int TotalEmployee {  get; set; }
        public decimal? TotalGross { get; set; }
        public decimal? TotalDeductions { get; set; }
        public decimal? TotalNet { get; set; }

        public ICollection<Payslip> Payslips { get; set; } = new List<Payslip>();

    }
}
