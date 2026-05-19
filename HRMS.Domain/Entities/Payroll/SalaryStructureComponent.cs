using HRMS.Domain.Common;

namespace HRMS.Domain.Entities.Payroll
{
    public class SalaryStructureComponent : BaseEntity
    {
        public Guid SalaryStructureId { get; set; }
        public Guid ComponentId { get; set; }
        public decimal Amount { get; set; }
        public decimal? Percentage { get; set; }

        public EmployeeSalaryStructure SalaryStructure { get; set; } = null!;
        public SalaryComponent Component { get; set; } = null!;

    }
}
