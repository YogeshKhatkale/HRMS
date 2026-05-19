using HRMS.Domain.Common;

namespace HRMS.Domain.Entities.Payroll
{
    public class EmployeeSalaryStructure : BaseEntity
    {
        public Guid EmployeeId { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime EffectiveTo { get; set; }
        public decimal GrossSalary { get; set; }
        public decimal NetSalary { get; set; }
        public bool IsActive { get; set; } = true;

        public HRMS.Domain.Entities.Employee.Employee Employee { get; set; } = null!;
        public ICollection<SalaryStructureComponent> Components { get; set; } = new List<SalaryStructureComponent>();
    }
}
