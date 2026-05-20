using HRMS.Domain.Entities.Attendance;
using HRMS.Domain.Entities.Employee;
using HRMS.Domain.Entities.Identity;
using HRMS.Domain.Entities.Organization;
using HRMS.Domain.Entities.Payroll;
using HRMS.Domain.Entities.Recruitment;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Infrastructure.Persistence;

public class HRMSDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public HRMSDbContext(DbContextOptions<HRMSDbContext> options) : base(options) { }

    // Organization
    public DbSet<Company> Companies => Set<Company>();
    public DbSet<Branch> Branches => Set<Branch>();
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Designation> Designations => Set<Designation>();

    // Employee
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<EmployeeDocument> EmployeeDocuments => Set<EmployeeDocument>();
    public DbSet<EmployeeBankDetail> EmployeeBankDetails => Set<EmployeeBankDetail>();
    public DbSet<EmployeeEmergencyContact> EmployeeEmergencyContacts => Set<EmployeeEmergencyContact>();
    public DbSet<EmployeeExperience> EmployeeExperiences => Set<EmployeeExperience>();
    public DbSet<EmployeeEducation> EmployeeEducations => Set<EmployeeEducation>();

    // Attendance
    public DbSet<Shift> Shifts => Set<Shift>();
    public DbSet<EmployeeShift> EmployeeShifts => Set<EmployeeShift>();
    public DbSet<Holiday> Holidays => Set<Holiday>();
    public DbSet<Attendance> Attendances => Set<Attendance>();
    public DbSet<AttendanceRegularization> AttendanceRegularizations => Set<AttendanceRegularization>();

    // Payroll
    public DbSet<SalaryComponent> SalaryComponents => Set<SalaryComponent>();
    public DbSet<EmployeeSalaryStructure> EmployeeSalaryStructures => Set<EmployeeSalaryStructure>();
    public DbSet<SalaryStructureComponent> SalaryStructureComponents => Set<SalaryStructureComponent>();
    public DbSet<PayrollRun> PayrollRuns => Set<PayrollRun>();
    public DbSet<Payslip> Payslips => Set<Payslip>();
    public DbSet<PayslipComponent> PayslipComponents => Set<PayslipComponent>();

    // Recruitment
    public DbSet<JobPosting> JobPostings => Set<JobPosting>();
    public DbSet<Candidate> Candidates => Set<Candidate>();
    public DbSet<JobApplication> JobApplications => Set<JobApplication>();
    public DbSet<InterviewRound> InterviewRounds => Set<InterviewRound>();
    public DbSet<OfferLetter> OfferLetters => Set<OfferLetter>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // ── Employee relationships ──────────────────────────
        builder.Entity<Employee>()
            .HasOne(e => e.User)
            .WithOne(u => u.Employee)
            .HasForeignKey<Employee>(e => e.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Employee>()
            .HasOne(e => e.Department)
            .WithMany(d => d.Employees)
            .HasForeignKey(e => e.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Employee>()
            .HasOne(e => e.Designation)
            .WithMany(d => d.Employees)
            .HasForeignKey(e => e.DesignationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Employee>()
            .HasOne(e => e.Branch)
            .WithMany(b => b.Employees)
            .HasForeignKey(e => e.BranchId)
            .OnDelete(DeleteBehavior.Restrict);

        // Employee self referencing
        builder.Entity<Employee>()
            .HasOne(e => e.ReportingManager)
            .WithMany(e => e.Subordinates)
            .HasForeignKey(e => e.ReportingManagerId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        // ── Department self referencing ─────────────────────
        builder.Entity<Department>()
            .HasOne(d => d.ParentDepartment)
            .WithMany(d => d.SubDepartments)
            .HasForeignKey(d => d.ParentDeptId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        // ── InterviewRound ──────────────────────────────────
        builder.Entity<InterviewRound>()
            .HasOne(i => i.Interviewer)
            .WithMany()
            .HasForeignKey(i => i.InterviewerId)
            .OnDelete(DeleteBehavior.Restrict);
        // ── JobPosting relationships ────────────────────────
        builder.Entity<JobPosting>()
            .HasOne(j => j.Department)
            .WithMany()
            .HasForeignKey(j => j.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<JobPosting>()
            .HasOne(j => j.Designation)
            .WithMany()
            .HasForeignKey(j => j.DesignationId)
            .OnDelete(DeleteBehavior.Restrict);

        // ── Attendance relationships ────────────────────────
        builder.Entity<Attendance>()
            .HasOne(a => a.Employee)
            .WithMany(e => e.Attendances)
            .HasForeignKey(a => a.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<AttendanceRegularization>()
            .HasOne(a => a.Employee)
            .WithMany()
            .HasForeignKey(a => a.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<EmployeeShift>()
            .HasOne(e => e.Employee)
            .WithMany()
            .HasForeignKey(e => e.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        // ── Payroll relationships ───────────────────────────
        builder.Entity<EmployeeSalaryStructure>()
            .HasOne(e => e.Employee)
            .WithMany(e => e.SalaryStructures)
            .HasForeignKey(e => e.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Payslip>()
            .HasOne(p => p.Employee)
            .WithMany(e => e.Payslips)
            .HasForeignKey(p => p.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        // ── Employee sub-entity relationships ───────────────
        builder.Entity<EmployeeDocument>()
            .HasOne(e => e.Employee)
            .WithMany(e => e.Documents)
            .HasForeignKey(e => e.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<EmployeeBankDetail>()
            .HasOne(e => e.Employee)
            .WithMany(e => e.BankDetails)
            .HasForeignKey(e => e.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<EmployeeEmergencyContact>()
            .HasOne(e => e.Employee)
            .WithMany(e => e.EmergencyContacts)
            .HasForeignKey(e => e.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<EmployeeExperience>()
            .HasOne(e => e.Employee)
            .WithMany(e => e.Experiences)
            .HasForeignKey(e => e.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<EmployeeEducation>()
            .HasOne(e => e.Employee)
            .WithMany(e => e.Educations)
            .HasForeignKey(e => e.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        // ── Unique constraints ──────────────────────────────
        builder.Entity<Employee>()
            .HasIndex(e => e.EmployeeCode).IsUnique();

        builder.Entity<Employee>()
            .HasIndex(e => e.WorkEmail).IsUnique();

        builder.Entity<Attendance>()
            .HasIndex(a => new { a.EmployeeId, a.AttendanceDate })
            .IsUnique();

        builder.Entity<JobApplication>()
            .HasIndex(j => new { j.JobPostingId, j.CandidateId })
            .IsUnique();

        // ── Decimal precision ───────────────────────────────
        builder.Entity<Attendance>()
            .Property(a => a.WorkedHours).HasPrecision(4, 2);

        builder.Entity<Shift>()
            .Property(s => s.WorkingHours).HasPrecision(4, 2);

        builder.Entity<EmployeeSalaryStructure>()
            .Property(e => e.GrossSalary).HasPrecision(18, 2);

        builder.Entity<EmployeeSalaryStructure>()
            .Property(e => e.NetSalary).HasPrecision(18, 2);

        builder.Entity<SalaryStructureComponent>()
            .Property(s => s.Amount).HasPrecision(18, 2);

        builder.Entity<SalaryStructureComponent>()
            .Property(s => s.Percentage).HasPrecision(5, 2);

        builder.Entity<PayrollRun>()
            .Property(p => p.TotalGross).HasPrecision(18, 2);

        builder.Entity<PayrollRun>()
            .Property(p => p.TotalDeductions).HasPrecision(18, 2);

        builder.Entity<PayrollRun>()
            .Property(p => p.TotalNet).HasPrecision(18, 2);

        builder.Entity<Payslip>()
            .Property(p => p.GrossSalary).HasPrecision(18, 2);

        builder.Entity<Payslip>()
            .Property(p => p.TotalEarnings).HasPrecision(18, 2);

        builder.Entity<Payslip>()
            .Property(p => p.TotalDeductions).HasPrecision(18, 2);

        builder.Entity<Payslip>()
            .Property(p => p.NetSalary).HasPrecision(18, 2);

        builder.Entity<Payslip>()
            .Property(p => p.PresentDays).HasPrecision(5, 2);

        builder.Entity<Payslip>()
            .Property(p => p.LeaveDays).HasPrecision(5, 2);

        builder.Entity<Payslip>()
            .Property(p => p.AbsentDays).HasPrecision(5, 2);

        builder.Entity<PayslipComponent>()
            .Property(p => p.Amount).HasPrecision(18, 2);

        builder.Entity<Candidate>()
            .Property(c => c.TotalExperience).HasPrecision(4, 2);

        builder.Entity<Candidate>()
            .Property(c => c.CurrentSalary).HasPrecision(18, 2);

        builder.Entity<Candidate>()
            .Property(c => c.ExpectedSalary).HasPrecision(18, 2);

        builder.Entity<JobPosting>()
            .Property(j => j.SalaryMin).HasPrecision(18, 2);

        builder.Entity<JobPosting>()
            .Property(j => j.SalaryMax).HasPrecision(18, 2);

        builder.Entity<OfferLetter>()
            .Property(o => o.OfferedSalary).HasPrecision(18, 2);

        // ── Global soft delete filters ──────────────────────
        builder.Entity<Employee>()
            .HasQueryFilter(e => !e.IsDeleted);
        builder.Entity<Department>()
            .HasQueryFilter(e => !e.IsDeleted);
        builder.Entity<Designation>()
            .HasQueryFilter(e => !e.IsDeleted);
    }
}