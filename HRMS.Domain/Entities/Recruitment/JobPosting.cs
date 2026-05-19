using HRMS.Domain.Common;
using HRMS.Domain.Entities.Organization;
namespace HRMS.Domain.Entities.Recruitment
{
    public class JobPosting : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public Guid DepartmentId { get; set; }
        public Guid DesignationId { get; set; }
        public int Vacancies { get; set; } = 1;
        public string JobType { get; set; } = string.Empty; // e.g., Full-time, Part-time, Contract
        public string? Location { get; set; }
        public int? ExperienceMin { get; set; }
        public int? ExperienceMax { get; set; }
        public decimal? SalaryMin { get; set; }
        public decimal? SalaryMax { get; set; }
        public string? Description { get; set; }
        public string? Requirements { get; set; }
        public string Status { get; set; } = "Open"; // e.g., Open, Closed, On Hold
        public DateTime PostedDate { get; set; } = DateTime.UtcNow;
        public DateTime? ClosingDate { get; set; }

        public Department Department { get; set; } = null!;
        public Designation Designation { get; set; } = null!;
        public ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();


    }
}
