using HRMS.Domain.Common;


namespace HRMS.Domain.Entities.Recruitment
{
    public class Candidate : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? ResumeUrl { get; set; }
        public decimal? TotalExperience { get; set; } // in years
        public string? CurrentCopany { get; set; }
        public decimal? CurrentSalary { get; set; }
        public decimal? ExpectedSalary { get; set; }
       public int? NoticePeriod { get; set; } // in days
        public string? Skills { get; set; } // comma-separated list of skills
       public string? Source { get; set; } // e.g., LinkedIn, Referral, Job Portal
       
        public ICollection<JobApplication> Applications { get; set; } = new List<JobApplication>();
    }
}
