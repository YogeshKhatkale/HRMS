using HRMS.Domain.Common;


namespace HRMS.Domain.Entities.Payroll
{
    public class SalaryComponent : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Type {  get; set; } = string.Empty;
       public string  CalculationType {  get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

    }
}
