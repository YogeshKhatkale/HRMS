using HRMS.Domain.Entities.Employee;
using HRMS.Domain.Entities.Organization;
using HRMS.Domain.Entities.Attendance;
using HRMS.Domain.Entities.Payroll;
using HRMS.Domain.Entities.Recruitment;

namespace HRMS.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    // Organization
    IGenericRepository<Company> Companies { get; }
    IGenericRepository<Branch> Branches { get; }
    IGenericRepository<Department> Departments { get; }
    IGenericRepository<Designation> Designations { get; }

    // Employee
    IGenericRepository<Employee> Employees { get; }
    IGenericRepository<EmployeeDocument> EmployeeDocuments { get; }
    IGenericRepository<EmployeeBankDetail> EmployeeBankDetails { get; }
    IGenericRepository<EmployeeEmergencyContact> EmployeeEmergencyContacts { get; }
    IGenericRepository<EmployeeExperience> EmployeeExperiences { get; }
    IGenericRepository<EmployeeEducation> EmployeeEducations { get; }

    // Attendance
    IGenericRepository<Shift> Shifts { get; }
    IGenericRepository<EmployeeShift> EmployeeShifts { get; }
    IGenericRepository<Holiday> Holidays { get; }
    IGenericRepository<HRMS.Domain.Entities.Attendance.Attendance> Attendances { get; }
    IGenericRepository<AttendanceRegularization> AttendanceRegularizations { get; }

    // Payroll
    IGenericRepository<SalaryComponent> SalaryComponents { get; }
    IGenericRepository<EmployeeSalaryStructure> EmployeeSalaryStructures { get; }
    IGenericRepository<SalaryStructureComponent> SalaryStructureComponents { get; }
    IGenericRepository<PayrollRun> PayrollRuns { get; }
    IGenericRepository<Payslip> Payslips { get; }
    IGenericRepository<PayslipComponent> PayslipComponents { get; }

    // Recruitment
    IGenericRepository<JobPosting> JobPostings { get; }
    IGenericRepository<Candidate> Candidates { get; }
    IGenericRepository<JobApplication> JobApplications { get; }
    IGenericRepository<InterviewRound> InterviewRounds { get; }
    IGenericRepository<OfferLetter> OfferLetters { get; }

    Task<int> SaveChangesAsync();
}