using HRMS.Domain.Common;

namespace HRMS.Domain.Entities.Recruitment
{
    public class JobApplication : BaseEntity
    {
        public Guid JobPostingId { get; set; }
        public Guid CandidateId { get; set; }
        public DateTime AppliedDate { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Applied"; // e.g., Applied, In Review, Interview Scheduled, Offered, Rejected
        public string? Remarks { get; set; }

        public JobPosting JobPosting { get; set; } = null!;
        public Candidate Candidate { get; set; } = null!;
        public ICollection<InterviewRound> InterviewRounds { get; set; } = new List<InterviewRound>();
        public OfferLetter? OfferLetter { get; set; }
    }
}
