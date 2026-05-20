using HRMS.Application.Interfaces;
using HRMS.Domain.Entities.Attendance;
using HRMS.Domain.Entities.Employee;
using HRMS.Domain.Entities.Organization;
using HRMS.Domain.Entities.Payroll;
using HRMS.Domain.Entities.Recruitment;
using HRMS.Infrastructure.Persistence;

namespace HRMS.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly HRMSDbContext _context;

    // Organization
    public IGenericRepository<Company> Companies { get; private set; }
    public IGenericRepository<Branch> Branches { get; private set; }
    public IGenericRepository<Department> Departments { get; private set; }
    public IGenericRepository<Designation> Designations { get; private set; }

    // Employee
    public IGenericRepository<Employee> Employees { get; private set; }
    public IGenericRepository<EmployeeDocument> EmployeeDocuments { get; private set; }
    public IGenericRepository<EmployeeBankDetail> EmployeeBankDetails { get; private set; }
    public IGenericRepository<EmployeeEmergencyContact> EmployeeEmergencyContacts { get; private set; }
    public IGenericRepository<EmployeeExperience> EmployeeExperiences { get; private set; }
    public IGenericRepository<EmployeeEducation> EmployeeEducations { get; private set; }

    // Attendance
    public IGenericRepository<Shift> Shifts { get; private set; }
    public IGenericRepository<EmployeeShift> EmployeeShifts { get; private set; }
    public IGenericRepository<Holiday> Holidays { get; private set; }
    public IGenericRepository<HRMS.Domain.Entities.Attendance.Attendance> Attendances { get; private set; }
    public IGenericRepository<AttendanceRegularization> AttendanceRegularizations { get; private set; }

    // Payroll
    public IGenericRepository<SalaryComponent> SalaryComponents { get; private set; }
    public IGenericRepository<EmployeeSalaryStructure> EmployeeSalaryStructures { get; private set; }
    public IGenericRepository<SalaryStructureComponent> SalaryStructureComponents { get; private set; }
    public IGenericRepository<PayrollRun> PayrollRuns { get; private set; }
    public IGenericRepository<Payslip> Payslips { get; private set; }
    public IGenericRepository<PayslipComponent> PayslipComponents { get; private set; }

    // Recruitment
    public IGenericRepository<JobPosting> JobPostings { get; private set; }
    public IGenericRepository<Candidate> Candidates { get; private set; }
    public IGenericRepository<JobApplication> JobApplications { get; private set; }
    public IGenericRepository<InterviewRound> InterviewRounds { get; private set; }
    public IGenericRepository<OfferLetter> OfferLetters { get; private set; }

    public UnitOfWork(HRMSDbContext context)
    {
        _context = context;

        // Organization
        Companies = new GenericRepository<Company>(_context);
        Branches = new GenericRepository<Branch>(_context);
        Departments = new GenericRepository<Department>(_context);
        Designations = new GenericRepository<Designation>(_context);

        // Employee
        Employees = new GenericRepository<Employee>(_context);
        EmployeeDocuments = new GenericRepository<EmployeeDocument>(_context);
        EmployeeBankDetails = new GenericRepository<EmployeeBankDetail>(_context);
        EmployeeEmergencyContacts = new GenericRepository<EmployeeEmergencyContact>(_context);
        EmployeeExperiences = new GenericRepository<EmployeeExperience>(_context);
        EmployeeEducations = new GenericRepository<EmployeeEducation>(_context);

        // Attendance
        Shifts = new GenericRepository<Shift>(_context);
        EmployeeShifts = new GenericRepository<EmployeeShift>(_context);
        Holidays = new GenericRepository<Holiday>(_context);
        Attendances = new GenericRepository<HRMS.Domain.Entities.Attendance.Attendance>(_context);
        AttendanceRegularizations = new GenericRepository<AttendanceRegularization>(_context);

        // Payroll
        SalaryComponents = new GenericRepository<SalaryComponent>(_context);
        EmployeeSalaryStructures = new GenericRepository<EmployeeSalaryStructure>(_context);
        SalaryStructureComponents = new GenericRepository<SalaryStructureComponent>(_context);
        PayrollRuns = new GenericRepository<PayrollRun>(_context);
        Payslips = new GenericRepository<Payslip>(_context);
        PayslipComponents = new GenericRepository<PayslipComponent>(_context);

        // Recruitment
        JobPostings = new GenericRepository<JobPosting>(_context);
        Candidates = new GenericRepository<Candidate>(_context);
        JobApplications = new GenericRepository<JobApplication>(_context);
        InterviewRounds = new GenericRepository<InterviewRound>(_context);
        OfferLetters = new GenericRepository<OfferLetter>(_context);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}