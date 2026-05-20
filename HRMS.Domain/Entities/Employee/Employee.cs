using HRMS.Domain.Common;
using HRMS.Domain.Entities.Identity;
using HRMS.Domain.Entities.Payroll;

namespace HRMS.Domain.Entities.Employee;

public class Employee : BaseEntity
{
    public string EmployeeCode { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public Guid DepartmentId { get; set; }
    public Guid DesignationId { get; set; }
    public Guid BranchId { get; set; }
    public Guid? ReportingManagerId { get; set; }

    // Personal Info
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime? DateOfBirth { get; set; }
    public string? Gender { get; set; }
    public string? MaritalStatus { get; set; }
    public string? Nationality { get; set; }
    public string? ProfilePhoto { get; set; }

    // Contact
    public string? PersonalEmail { get; set; }
    public string WorkEmail { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public string? AlternatePhone { get; set; }

    // Address
    public string? CurrentAddress { get; set; }
    public string? PermanentAddress { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public string? PostalCode { get; set; }

    // Employment
    public DateTime JoiningDate { get; set; }
    public DateTime? ConfirmationDate { get; set; }
    public DateTime? ProbationEndDate { get; set; }
    public string EmploymentType { get; set; } = string.Empty;
    public string EmploymentStatus { get; set; } = string.Empty;
    public string? WorkLocation { get; set; }
    public bool IsActive { get; set; } = true;

    // Navigation Properties
    public ApplicationUser User { get; set; } = null!;
    public HRMS.Domain.Entities.Organization.Department Department { get; set; } = null!;
    public HRMS.Domain.Entities.Organization.Designation Designation { get; set; } = null!;
    public HRMS.Domain.Entities.Organization.Branch Branch { get; set; } = null!;
    public Employee? ReportingManager { get; set; }
    public ICollection<Employee> Subordinates { get; set; } = new List<Employee>();
    public ICollection<EmployeeDocument> Documents { get; set; } = new List<EmployeeDocument>();
    public ICollection<EmployeeBankDetail> BankDetails { get; set; } = new List<EmployeeBankDetail>();
    public ICollection<EmployeeEmergencyContact> EmergencyContacts { get; set; } = new List<EmployeeEmergencyContact>();
    public ICollection<EmployeeExperience> Experiences { get; set; } = new List<EmployeeExperience>();
    public ICollection<EmployeeEducation> Educations { get; set; } = new List<EmployeeEducation>();
    public ICollection<HRMS.Domain.Entities.Attendance.Attendance> Attendances { get; set; } = new List<HRMS.Domain.Entities.Attendance.Attendance>();
    public ICollection<EmployeeSalaryStructure> SalaryStructures { get; set; } = new List<EmployeeSalaryStructure>();
    public ICollection<Payslip> Payslips { get; set; } = new List<Payslip>();
}