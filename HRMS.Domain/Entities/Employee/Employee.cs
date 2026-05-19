using HRMS.Domain.Common;
using HRMS.Domain.Entities.Identity;
using HRMS.Domain.Entities.Organization;

namespace HRMS.Domain.Entities.Employee
{
    public class Employee : BaseEntity
    {
        public string EmployeeCode { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid DesignationId { get; set; }
        public Guid BranchId { get; set; }
        public Guid? ReportingManaggerId { get; set; }

        // personal details

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? MaritalStatus { get; set; }
        public string? Natonality { get; set; }
        public string? ProfilePhoto { get; set; }

        // contact details
        public string? PersonalEmail { get; set; }
        public string WorkEmail { get; set; }
        public string? Phone { get; set; }
        public string? AlternatePhone { get; set; }

        //Address details

        public string? CurrentAddress { get; set; }
        public string? PermanentAddress { get; set; }
        public string?  City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? PostalCode { get; set; }

        // employment details
        public DateTime JoiningDate { get; set; }
        public DateTime? ConfirmationDate { get; set; }
        public DateTime? ProbationEndDate { get; set; }
        public string EmploymentType { get; set; } = string.Empty; // e.g., Full-time, Part-time, Contract
        public string EmploymentStatus { get; set; } = string.Empty; // e.g., Active, Inactive, Terminated
        public string? WorkLocation { get; set; }
        public bool IsActive { get; set; } = true; // Indicates whether the employee is active

        // Navigation properties

        public ApplicationUser User { get; set; } = null!; // Navigation property for the related user
        public Department Department { get; set; } = null!; // Navigation property for the related department
        public Designation Designation { get; set; } = null!; // Navigation property for the related designation
        public Branch Branch { get; set; } = null!; // Navigation property for the related branch
         public Employee? ReportingManager { get; set; } // Navigation property for the reporting manager (self-referencing)
        public ICollection<Employee> Subordinates { get; set; } = new List<Employee>(); // Navigation property for employees reporting to this employee
        public ICollection<EmployeeDocument> Documents { get; set; } = new List<EmployeeDocument>(); // Navigation property for related employee documents
        public ICollection<EmployeeBankDetail> BankDetails { get; set; } = new List<EmployeeBankDetail>(); // Navigation property for related employee bank details
        public ICollection<EmployeeEmergencyContact> EmergencyContacts { get; set; } = new List<EmployeeEmergencyContact>(); // Navigation property for related employee emergency contacts
        public ICollection<EmployeeExperience> Experiences { get; set; } = new List<EmployeeExperience>(); // Navigation property for related employee experiences
         public ICollection<EmployeeEducation> Educations { get; set; } = new List<EmployeeEducation>(); // Navigation property for related employee education details
    }
}

