using HRMS.Domain.Entities.Employee;
using HRMS.Domain.Entities.Attendance;
using HRMS.Domain.Entities.Identity;
using HRMS.Domain.Entities.Organization;
using HRMS.Domain.Entities.Payroll;
using HRMS.Domain.Entities.Recruitment;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Infrastructure.Persistence
{
    public class HRMSDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public HRMSDbContext(DbContextOptions<HRMSDbContext> options) : base(options) { }

        // organization

        public DbSet<Company> Companies => Set<Company>();
        public DbSet<Branch> Branches => Set<Branch>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Designation> Designations => Set<Designation>();

        //Employee

        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<EmployeeDocument> EmployeeDocuments => Set<EmployeeDocument>();
        public DbSet<EmployeeBankDetail> EmployeeBankDetails => Set<EmployeeBankDetail>();
        public DbSet<EmployeeEmergencyContact> EmployeeEmergencyContacts => Set<EmployeeEmergencyContact>();
        public DbSet<EmployeeExperience> EmployeeExperiences => Set<EmployeeExperience>();
        public DbSet<EmployeeEducation> EmployeeEducations => Set<EmployeeEducation>();

        //Attendance

        public DbSet<Shift> Shifts => Set<Shift>();
        public DbSet<EmployeeShift> EmployeeShifts => Set<EmployeeShift>();
        public DbSet<Holiday> Holidays => Set<Holiday>();
        public DbSet<Attendance> Attendances => Set<Attendance>();
        public DbSet<AttendanceRegularization> AttendanceRegularizations => Set<AttendanceRegularization>();

        //payroll

        public DbSet<SalaryComponent> SalaryComponents => Set<SalaryComponent>();
        public DbSet<EmployeeSalaryStructure> EmployeeSalaryStructures => Set<EmployeeSalaryStructure>();
        public DbSet<SalaryStructureComponent> SalaryStructureComponents => Set<SalaryStructureComponent>();
        public DbSet<PayrollRun> PayrollRuns => Set<PayrollRun>();
        public DbSet<Payslip> payslips => Set<Payslip>();
        public DbSet<PayslipComponent> PayslipComponents => Set<PayslipComponent>();

        //recruitment

        public DbSet<JobOpening> JobOpenings => Set<JobOpening>();
        public DbSet<Candidate> Candidates => Set<Candidate>();
        public DbSet<JobApplicaton> JobApplcations => Set<JobApplicaton>();
        public DbSet<InterviewRound> InterviewRounds => Set<InterviewRound>();
        public DbSet<OfferLetter> OfferLetters => Set<OfferLetter>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            // Self refrencing  - Employee reporting manager 
            builder.Entity<Employee>()
                .HasOne(e => e.ReportingManager)
                .WithMany(e => e.Subordinates)
                .HasForeignKey(e => e.ReportingManager)
                .OnDelete(DeleteBehaviour.Restrict);

            // Self referencing - Department parent 
            builder.Entity<Department>()
                .HasOne(d => d.ParentDepartment)
                .WithMany(d => d.SubDepartments)
                .HasForeignKey(d => d.ParentDeptId)
                .OnDelete(DeleteBehaviour.Restrict);

            // Unique constraint

            builder.Entity<Employee>()
                .HasIndex(e => e.EmployeeCode).IsUnique();

            builder.Entity<Employee>()
                .HasIndex(e => e.WorkEmail).IsUnique();

            builder.Entity<Attendance>()
                .HasIndex(a => a.EmployeeId, a.AttendanceDate).IsUnique();

            builder.Entity<JobApplication>()
               .HasIndex(j => new { j.JobPostingId, j.CandidateId }).IsUnique();

            // Global soft delete flters

            builder.Entity<Employee>().HasQueryFilter(e => !e.IsDeleted);

            builder.Entity<Department>().HasQueryFilter(e => !e.IsDeleted);
            builder.Entity<Designation>().HasQueryFilter(e => !e.IsDeleted);


        }
    }
